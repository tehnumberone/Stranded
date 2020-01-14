import character from "./character.js";
import inputHandler from "./input.js";
import inventory from "./inventory.js";
import mainMenu from "./mainMenu.js";
import map from "./map.js";
import level from "./level.js";
import item from "./item.js";

const gameState = {
    RUNNING: 0,
    INVENTORY: 1,
    MAINMENU: 2,
    CHARACTERSTATS: 3,
    PAUSED: 4
}

export default class gameLogic {
    constructor(gameHeight, gameWidth, canvas) {
        this.go = false;
        this.gameHeight = gameHeight;
        this.gameWidth = gameWidth;
        this.gameState = gameState.MAINMENU;
        this.canvas = canvas;
        this.currentLevel = 1;
        this.charmodel = document.getElementById("character");
        this.levels = [];
        this.inventoryImage = document.getElementById("inventoryImg");
        this.mainMenuImage = document.getElementById("mainmenuImg");
        this.char = new character(this, this.charmodel, 1);
        this.map = new map(this, this.mapImage);
        this.inv = new inventory(this, this.inventoryImage);
        this.mMenu = new mainMenu(this, this.mainMenuImage, canvas);
        this.level = new level(this, document.getElementById("level1img"), this.currentLevel, this.loadAllItems(), this.char);
        new inputHandler(this.char, this);
        this.gameObjects = [];
        this.getMousePos = { x: 0, y: 0 };
        this.mouseposX;
        this.mouseposY;
        this.clicked = false;
        this.tempLevel;
    }

    initialize() {
        if (this.gameState === gameState.RUNNING) {
            //load in game objects
            this.gameObjects = [
                this.level,
                this.char
            ];
            this.loadLevels();
        } else {
            return; // if still on mainmenu, exit function
        }
    }

    update(deltaTime) {
        this.gameObjects = [
            this.level,
            this.char
        ];
        this.gameObjects.forEach((object) =>
            object.update(deltaTime));//updates location of game objects
        if (this.clicked === true) {// check waar er geklikt wordt
            this.clicked = false;
            if (this.mouseposX >= 83 && this.mouseposX <= 138 && this.mouseposY >= 617 && this.mouseposY <= 639 && this.gameState === gameState.MAINMENU) {
                this.gameState = gameState.RUNNING;
                this.initialize();
            }
        }
        this.nextLevel();
    }

    draw(ctx) {
        if (this.gameState === gameState.RUNNING) {
            this.gameObjects.forEach((object) =>
                object.draw(ctx));//draws each gameobject
        }
        else if (this.gameState === gameState.INVENTORY) {
            this.inv = this.level.character.inventory;
            this.inv.draw(ctx);//draw inventory
        }
        else if (this.gameState === gameState.MAINMENU) {
            this.mMenu.draw(ctx);//draw mainmenu
        }
        if (this.levels.length > 0)
            this.level = this.levels[this.currentLevel - 1];
        ctx.fillText("Current Level: " + this.currentLevel, 50, 100);
        //else if (this.gameState == this.gameState.CHARACTERSTATS) {
        //    this.characterStats.draw(ctx);
        //}
    }

    checkClickLocation(e) {
        var r = this.canvas.getBoundingClientRect();
        this.mouseposX = e.clientX - r.left;
        this.mouseposY = e.clientY - r.top;
        this.clicked = true;
    }

    openInventory() {//if inventory is open, close it, if its not open, open it
        if (this.gameState === gameState.INVENTORY) {
            this.gameState = gameState.RUNNING;
        }
        else if (this.gameState === gameState.RUNNING) this.gameState = gameState.INVENTORY;
    }

    toggleMainmenu() {//if mainmenu is open, close it, if its not open, open it
        if (this.gameState === gameState.MAINMENU) {
            this.gameState = gameState.RUNNING;
        }
        else if (this.gameState !== gameState.INVENTORY) {
            this.gameState = gameState.MAINMENU;
        }
    }

    nextLevel() {
        if (this.char.previousLevel && this.currentLevel > 1) {
            this.currentLevel--;
            this.char.currentLevel = this.currentLevel;
            this.loadLevels();
        }
        if (this.char.nextLevel && this.currentLevel < 10) {
            this.currentLevel++;
            this.char.currentLevel = this.currentLevel;
            this.loadLevels();
        }
        this.char.nextLevel = false;
        this.char.previousLevel = false;
    }

    loadLevels() {
        //Loading ALL background images for each level.
        this.levels = [];
        for (var i = 1; i < 11; i++) {
            this.tempLevel = new level(this, document.getElementById("level" + i + "img"), this.currentLevel, this.loadAllItems(), this.char);
            this.levels.push(this.tempLevel);
        }
    }

    loadAllItems() {
        //Loading all items in the game.
        var tempList = document.getElementsByClassName("item");
        var allItems = [];
        for (var i = 0; i < tempList.length; i++) {
            var tempItem = new item(this, tempList[i]);
            allItems.push(tempItem);
        }
        console.log(allItems);
        return allItems;
    }
}