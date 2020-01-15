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
    }
    draw(ctx) {
        ctx.drawImage(this.charmodel, this.position.x, this.position.y, this.width, this.height);
    }
    update(deltaTime) {
        if (!deltaTime) return;
        this.exceededBorder();
            window.HP = this.hp;
            window.Hunger = this.hunger;
            window.Hydration = this.hydration;
    }
    exceededBorder(){
        if (this.position.x < 0 && this.currentLevel > 1) {//check left side.
            this.position.x = this.gameWidth - (this.width * 2);
            this.previousLevel = true;
        }
        if (this.position.x < 0 && this.currentLevel === 1) {//check left side.
            this.position.x = 0;
            this.previousLevel = false;
        }
        if (this.position.x > this.gameWidth - this.width && this.currentLevel < 10) {//check right side
            this.position.x = this.width;
            this.nextLevel = true;
        }
        if (this.position.x > this.gameWidth - this.width && this.currentLevel === 10) {//check right side
            this.position.x = this.gameWidth - this.width;
            this.nextLevel = false;
        }
    }
    moveLeft() {
        this.position.x += (this.speed = -this.maxSpeed);
    }
    moveRight() {
        this.position.x += (this.speed = this.maxSpeed);
    }
    /*moveUp() {
        this.position.y += (this.speed = -this.maxSpeed);
    }
    moveDown() {
        this.position.y += (this.speed = this.maxSpeed);
    }
    */
}

