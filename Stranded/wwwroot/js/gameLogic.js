import character from "./character.js";
import inputHandler from "./input.js";
import inventory from "./inventory.js";
import mainMenu from "./mainMenu.js";
import map from "./map.js";
import level from "./level.js";
import item from "./item.js";
import collisionDetection from "./collisionDetection.js";

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
        this.inventoryImage = document.getElementById("inventoryImg");
        this.mainMenuImage = document.getElementById("mainmenuImg");
        this.firstLevelImage = document.getElementById("level1img");
        this.levels = [];
        this.char = new character(this, this.charmodel, 1);
        this.map = new map(this, this.mapImage);
        this.inv = new inventory(this, this.inventoryImage);
        this.mMenu = new mainMenu(this, this.mainMenuImage, canvas);
        this.level = new level(this, this.firstLevelImage, this.currentLevel, this.loadAllItems());
        this.collisionDetection = new collisionDetection(1);
        new inputHandler(this.char, this);
        this.gameObjects = [];
        this.getMousePos = { x: 0, y: 0 };//x is horizontal y is vertical
        this.mouseposX;
        this.mouseposY;
        this.clicked = false;
        this.currentLevel;
        this.tempLevel;
        this.d = new Date();
        this.now = this.d.getSeconds();
        this.oldTime;
    }

    //#region Game Engine

    initialize() {
        this.loadCharacter();
        this.loadGameObjects();
    }

    update(deltaTime) {
        this.d = new Date();
        this.now = this.d.getSeconds();
        this.allGameObjects();

        this.gameObjects.forEach((object) =>
            object.update(deltaTime));
        this.onClick();             //check user click positions
        this.hungerAndThirst();     //update player survival stats
        this.nextLevel();           //advance to next level if border is reached
        this.saveProgress();        //saves progress TODO: only when changes have been made to character or level
        this.collision();           //checks all object collision
    }

    draw(ctx) {
        if (this.gameState === gameState.RUNNING || this.gameState === gameState.INVENTORY) {//draws each gameobject when game is started.
            this.gameObjects.forEach((object) =>
                object.draw(ctx));
            this.drawText(ctx);
            if (this.char.inventory.inventoryItems != undefined && this.gameState === gameState.INVENTORY) {
                this.inventoryHover(this.char.inventory.inventoryItems, ctx)
            }
        }
        else if (this.gameState === gameState.MAINMENU) {
            this.mMenu.draw(ctx);//draw mainmenu
        }
        if (this.levels.length > 0)
            this.level = this.levels[this.currentLevel - 1];
    }

    //#endregion Game Engine

    //#region Loading in the character 

    loadCharacter() {
        if (window.characterHunger !== undefined && window.characterHydration !== undefined && window.characterHP !== undefined
            && window.gameLevel !== undefined) {
            this.char.hunger = window.characterHunger;
            this.char.hydration = window.characterHydration;
            this.char.hp = window.characterHP;
            this.currentLevel = window.gameLevel;
            this.char.currentLevel = this.currentLevel;
        }
    }

    //#endregion Loading in the character 

    //#region Loading in game objects 

    loadGameObjects() {
        if (this.gameState === gameState.RUNNING) {
            this.allGameObjects();
            this.loadLevels2();
            this.collisionDetection = new collisionDetection(this.levels.length);
            this.oldTime = this.now;
        } else {
            return; // if still on mainmenu, exit function
        }
    }

    allGameObjects() {
        if (this.gameState === gameState.RUNNING) {
            this.gameObjects = [
                this.level,
                this.char
            ];
        }
        else if (this.gameState === gameState.INVENTORY) {
            this.gameObjects = [
                this.level,
                this.char,
                this.char.inventory
            ];
        }
    }

    //#endregion Loading in game objects

    //#region Character Data Logic

    changeCharacterParameters(character) {
        if (character.hunger > 0) {
            character.hunger = character.hunger - 1;
        }
        if (character.hunger === 0) {
            character.hp = character.hp - 1;
        }
        if (character.hydration > 0) {
            character.hydration = character.hydration - 1;
        }
        if (character.hydration === 0) {
            character.hp = character.hp - 1;
        }
        if (character.hp <= 0) {
            character.hp = 10;
            character.hydration = 10;
            character.hunger = 10;
            alert("You've died! try again..");
        }
    }

    hungerAndThirst() {
        if (this.gameState === gameState.RUNNING) {
            if (this.now === 0) {
                this.oldTime = 10;
            }
            if (this.char.hp !== undefined && this.char.hunger !== undefined && this.char.hydration !== undefined) {
                if (this.now >= this.oldTime) {
                    this.changeCharacterParameters(this.char);
                    this.oldTime = this.now + 10;
                    if (this.oldTime > 60) {
                        this.oldTime = 60;
                    }
                }
            }
        }
    }

    //#endregion Character Data Logic

    //#region Menu & UI logic

    onClick() {
        if (this.gameState === gameState.INVENTORY) {
            this.inventoryClick(this.char.inventory.inventoryItems);
        }
        else if (this.gameState === gameState.RUNNING && this.char.equippedItem != undefined) {
            this.unequipItem();
        }
        else if (this.gameState === gameState.MAINMENU) {
            this.mainMenuItemClick();
        }
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

    mainMenuItemClick() {
        if (this.clicked === true) {// check on which menu item the user has clicked.
            this.clicked = false;
            if (this.mouseposX >= 83 && this.mouseposX <= 138 && this.mouseposY >= 617 && this.mouseposY <= 639 && this.gameState === gameState.MAINMENU) {
                this.gameState = gameState.RUNNING;
                this.initialize();
            }
        }
    }

    inventoryClick(items) {
        if (this.clicked) {// check on which item the user has clicked.
            this.clicked = false;
            for (var i = 0; i < items.length; i++) {
                if (this.mouseOnObject(items[i]) &&
                    this.gameState === gameState.INVENTORY) {
                    this.gameState = gameState.RUNNING;
                    if (items[i].itemType === items[i].itemTypes.Weapon || items[i].itemType === items[i].itemTypes.Tool) {
                        this.char.equippedItem = items[i];
                        this.char.itemEquipped = true;
                    }
                    else if (items[i].itemType === items[i].itemTypes.Food) {
                        this.char.hunger = 10;
                        this.char.hydration = 10;
                        items.splice(i, 1);
                        this.char.inventory.inventoryItems = items;
                    }
                }
            }
        }
    }

    inventoryHover(items, ctx) {
        if (!this.clicked) {
            for (var i = 0; i < items.length; i++) {
                if (this.mouseOnObject(items[i]) &&
                    this.gameState === gameState.INVENTORY || this.gameState === gameState.RUNNING) {
                    this.showItemInfo(items[i], ctx);
                }
            }
        }
    }

    unequipItem() {
        if (this.clicked === true) {// check if user unequipped item
            this.clicked = false;
            if (this.mouseposX >= 675 && this.mouseposX <= 725 && this.mouseposY >= 75 && this.mouseposY <= 125 && this.gameState === gameState.RUNNING) {
                this.char.itemEquipped = false;
                this.char.equippedItem = null;
            }
        }
    }

    checkClickLocation(e) {
        var r = this.canvas.getBoundingClientRect();
        this.mouseposX = e.clientX - r.left;
        this.mouseposY = e.clientY - r.top;
        this.clicked = true;
    }

    checkHoverLocation(e) {
        var r = this.canvas.getBoundingClientRect();
        this.mouseposX = e.clientX - r.left;
        this.mouseposY = e.clientY - r.top;
    }

    mouseOnObject(object) {
        if (this.mouseposX >= object.position.x && this.mouseposX <= object.position.x + object.width &&
            this.mouseposY >= object.position.y && this.mouseposY <= object.position.y + object.height) {
            return true;
        }
    }

    //#endregion Menu & UI logic

    //#region Level logic

    nextLevel() {
        if (this.char.previousLevel && this.currentLevel > 1) {
            this.currentLevel--;
            this.char.currentLevel = this.currentLevel;
        }
        if (this.char.nextLevel && this.currentLevel < this.levels.length) {
            this.currentLevel++;
            this.char.currentLevel = this.currentLevel;
        }
        this.char.nextLevel = false;
        this.char.previousLevel = false;
    }

    levelLog() { // FOR TESTING PURPOSES
        console.log("game level");
        console.log(this.currentLevel);
        console.log("character level");
        console.log(this.char.currentLevel);
        if (this.levels.length > 0) {
            console.log("Level level");
            console.log(this.levels[this.currentLevel - 1].currentLevel);
        }
    }

    //#endregion Loading in the levels

    //#region All Levels

    loadLevels2() {
        this.levels = [];
        var allItems = this.loadAllItems();
        this.level1(allItems);
        this.level2(allItems);
        this.level3(allItems);
        this.level4(allItems);
        this.level5(allItems);
        this.level6(allItems);
        this.level7(allItems);
        this.level8(allItems);
        this.level9(allItems);
        this.level10(allItems);
    }

    level1(allItems) {
        var levelItems = [];
        allItems[0].itemName = "Dragon Dagger";
        allItems[0].itemType = allItems[0].itemTypes.Weapon
        levelItems.push(allItems[0]);
        //for (var i = 0; i < 27; i++) {//TEST & DEBUG PURPOSES TO FILL INVENTORY
        //    var tempitem = new item(this, allItems[0].itemModel);
        //    tempitem.itemName = "Dragon Dagger" + i;
        //    tempitem.itemType = tempitem.itemTypes.Weapon
        //    tempitem.position.x = tempitem.position.x;
        //    tempitem.position.y = tempitem.position.y;
        //    levelItems.push(tempitem);
        //}
        this.levels.push(
            new level(this, document.getElementById("level1img"), this.currentLevel, levelItems)
        );
    }

    level2(allItems) {
        var levelItems = [];
        this.levels.push(
            new level(this, document.getElementById("level2img"), this.currentLevel, levelItems)
        );
    }

    level3(allItems) {
        var levelItems = [];
        this.levels.push(
            new level(this, document.getElementById("level3img"), this.currentLevel, levelItems)
        );
    }

    level4(allItems) {
        var levelItems = [];
        this.levels.push(
            new level(this, document.getElementById("level4img"), this.currentLevel, levelItems)
        );
    }

    level5(allItems) {
        var levelItems = [];
        this.levels.push(
            new level(this, document.getElementById("level5img"), this.currentLevel, levelItems)
        );
    }

    level6(allItems) {
        var levelItems = [];
        this.levels.push(
            new level(this, document.getElementById("level6img"), this.currentLevel, levelItems)
        );
    }

    level7(allItems) {
        var levelItems = [];
        this.levels.push(
            new level(this, document.getElementById("level7img"), this.currentLevel, levelItems)
        );
    }

    level8(allItems) {
        var levelItems = [];
        this.levels.push(
            new level(this, document.getElementById("level8img"), this.currentLevel, levelItems)
        );
    }

    level9(allItems) {
        var levelItems = [];
        this.levels.push(
            new level(this, document.getElementById("level9img"), this.currentLevel, levelItems)
        );
    }

    level10(allItems) {
        var levelItems = [];
        allItems[3].itemName = "Apple";
        allItems[3].itemType = allItems[3].itemTypes.Food
        levelItems.push(allItems[3]);
        this.levels.push(
            new level(this, document.getElementById("level10img"), this.currentLevel, levelItems)
        );
    }

    //#endregion All Levels

    //#region Loading in the items

    loadAllItems() {
        //Loading all items in the game.
        var tempList = document.getElementsByClassName("item");
        var allItems = [];
        for (var i = 0; i < tempList.length; i++) {
            var tempItem = new item(this, tempList[i]);
            allItems.push(tempItem);
        }
        return allItems;
    }

    //#endregion Loading in the items

    //#region Checking character collision

    collision() {
        if (this.gameState === gameState.RUNNING) {
            this.characterCollision(this.char);
            if (this.level.levelItems.length > 0) {
                this.itemCollision(this.char, this.level);
            }
        }
    }

    characterCollision(character) {
        this.collisionDetection.exceededBorder(character);
    }

    itemCollision(character, level) {
        var levelItems = level.levelItems;
        if (this.char.inventory != undefined) {
            var invItems = this.char.inventory.inventoryItems;
            for (var i = 0; i < levelItems.length; i++) {
                if (this.collisionDetection.isColliding(character, levelItems[i])) {
                    invItems.push(levelItems[i]);
                    levelItems.splice(i, 1);
                    break;
                }
            }
        }
    }

    //#endregion Checking character collision

    //#region Save Game

    saveProgress() {
        this.saveCharacter();
        this.saveInventory();
    }

    saveCharacter() {
        window.Level = this.currentLevel;
        window.HP = this.char.hp;
        window.Hunger = this.char.hunger;
        window.Hydration = this.char.hydration;
    }

    saveInventory() {
        var characterInventory = this.char.inventory;
        if (characterInventory.inventoryItems != undefined) {
            var tempList = [];
            characterInventory.inventoryItems.forEach(element => tempList.push(element.itemModel.src));
            window.InventoryItems = tempList;
        }
    }

    //#endregion Save Game

    //#region Draw Text On Screen

    drawText(ctx) {
        ctx.font = "15px Georgia";
        if (this.char.hp > 0) {
            ctx.fillText("Level: " + this.currentLevel, 25, 50);
            ctx.fillText("Hitpoints: " + this.char.hp, 25, 100);
            ctx.fillText("Hydration: " + this.char.hydration, 25, 150);
            ctx.fillText("Hunger: " + this.char.hunger, 25, 200);
            ctx.fillText("Currently Equipped", 650, 50);
        }

        if (this.char.itemEquipped) {
            ctx.drawImage(this.char.equippedItem.itemModel, 675, 75, 50, 50);
        }
    }

    showItemInfo(item, ctx) {
        ctx.fillStyle = "#898282";
        ctx.fillText(item.itemName, 370, 525 - 43); // default x position + width / 2  = X // default y position + height = Y 
        ctx.fillText(item.itemType, 370, 525 - 12); //Some manual tweaking is needed to make positions perfect
        ctx.fillStyle = "#000000";
    }

    //#endregion Draw Text On Screen
}
