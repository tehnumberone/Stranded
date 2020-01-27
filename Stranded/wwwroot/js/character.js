import inventory from "./inventory.js";

export default class Character {
    constructor(gameLogic, charmodel, isNpc) {
        this.inventory;
        this.gameLogic = gameLogic;
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;
        this.width = 50;
        this.height = 75;
        this.maxSpeed = 25;
        this.speed = 0;
        this.position =
            {
                x: 0,
                y: this.gameHeight - this.height - 190
            };
        this.charmodel = charmodel;
        this.hunger = 10;
        this.hydration = 10;
        this.hp = 10;
        this.itemEquipped = false;
        this.equippedItem = null;
        this.isNpc = isNpc;
        this.initalized = false;
    }
    draw(ctx) {
        ctx.drawImage(this.charmodel, this.position.x, this.position.y, this.width, this.height);
    }
    update(deltaTime) {
        if (!this.isNpc && !this.initalized) {
            this.initializeInventory();
        }
        if (!deltaTime) return;
    }
    moveLeft() {
        this.position.x += (this.speed = - this.maxSpeed);
    }
    moveRight() {
        this.position.x += (this.speed = this.maxSpeed);
    }
    initializeInventory() {
        this.inventory = new inventory(this.gameLogic, document.getElementById("inventoryImg"));
        this.initalized = true;
    }
}

