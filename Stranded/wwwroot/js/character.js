import inventory from "./inventory.js";

export default class Character {
    constructor(gameLogic, charmodel, currentLevel) {
        this.inventory = new inventory(gameLogic, document.getElementById("inventoryImg"));
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
        this.nextLevel = false;
        this.previousLevel = false;
        this.currentLevel = currentLevel;
        this.hunger = 10;
        this.hydration = 10;
        this.hp = 10;
        this.itemEquipped = false;
        this.equippedItem;
    }
    draw(ctx) {
        ctx.drawImage(this.charmodel, this.position.x, this.position.y, this.width, this.height);
    }
    update(deltaTime) {
        if (!deltaTime) return;
    }
    moveLeft() {
        this.position.x += (this.speed = - this.maxSpeed);
    }
    moveRight() {
        this.position.x += (this.speed = this.maxSpeed);
    }
}

