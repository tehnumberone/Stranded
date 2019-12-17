import character from "./character.js";
import inputHandler from "./input.js";
import inventory from "./inventory.js";
import mainMenu from "./mainMenu.js";
import map from "./map.js";

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
        this.charmodel = document.getElementById("character");
        this.mapImage = document.getElementById("mapImg");
        this.inventoryImage = document.getElementById("inventoryImg");
        this.mainMenuImage = document.getElementById("mainmenuImg");
        this.char = new character(this, this.charmodel);
        this.map = new map(this, this.mapImage);
        this.inv = new inventory(this, this.inventoryImage);
        this.mMenu = new mainMenu(this, this.mainMenuImage, canvas);
        new inputHandler(this.char, this);
        this.gameObjects = [];
        this.getMousePos = { x: 0, y: 0 };
        this.mouseposX;
        this.mouseposY;
        this.clicked = false;
    }

    initialize() {
        if (this.gameState === gameState.RUNNING) {
            //load in game objects
            this.gameObjects = [
                this.char
            ];
        } else {
            return; // if still on mainmenu, exit function
        }
    }

    update(deltaTime) {
        this.gameObjects.forEach((object) =>
            object.update(deltaTime));//updates location of game objects

        if (this.clicked === true) {// check waar er geklikt wordt
            this.clicked = false;
            if (this.mouseposX >= 83 && this.mouseposX <= 138 && this.mouseposY >= 617 && this.mouseposY <= 639 && this.gameState === gameState.MAINMENU) {
                this.gameState = gameState.RUNNING;
                this.initialize();
            }
        }
    }

    draw(ctx) {
        if (this.gameState === gameState.RUNNING) {
            this.gameObjects.forEach((object) =>
                object.draw(ctx));//draws each gameobject
        }
        else if (this.gameState === gameState.INVENTORY) {
            this.inv.draw(ctx);//draw inventory
        }
        else if (this.gameState === gameState.MAINMENU) {
            this.mMenu.draw(ctx);//draw mainmenu
        }

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
}