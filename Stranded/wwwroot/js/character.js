import inventory from "./inventory.js";
const lastDirection = {
    Left: 0,
    Right: 1
}
export default class Character {
    constructor(gameLogic, charmodel, isNpc) {
        this.inventory;
        this.gameLogic = gameLogic;
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;
        this.charmodel = charmodel;
        this.width = this.charmodel.naturalWidth / 2;
        this.height = this.charmodel.naturalHeight;
        this.maxSpeed = 15;
        this.speed = 0;
        this.position =
            {
                x: 0,
                y: this.gameHeight - this.height - 190
            };
        this.hunger = 10;
        this.hydration = 10;
        this.hp = 10;
        this.itemEquipped = false;
        this.equippedItem = null;
        this.isNpc = false;
        this.initalized = false;
        this.lastDirection = lastDirection.Right;
    }
    draw(ctx) {
        var image = this.charmodel;
        var imageProportions = {
            width: image.naturalWidth,
            height: image.naturalHeight
        }
        if (!this.isNpc) {
            if (this.lastDirection == lastDirection.Left) {//draw the character with the direction towards the left.
                ctx.drawImage(image, 0, 0, this.width, this.height, this.position.x, this.position.y, imageProportions.width / 2, imageProportions.height);
            }
            else if (this.lastDirection == lastDirection.Right) {//draw the character with the direction towards the right.
                ctx.drawImage(image, imageProportions.width / 2, 0, this.width, this.height, this.position.x, this.position.y, imageProportions.width / 2, imageProportions.height);
            }
        }
        else if (this.gameLogic.char.position.x < this.position.x || this.gameLogic.char.position.x < this.position.x + this.width / 2 - this.gameLogic.char.maxSpeed) {
            ctx.drawImage(image, 0, 0, this.width, this.height, this.position.x, this.position.y, imageProportions.width / 2, imageProportions.height);
        }
        else if (this.gameLogic.char.position.x > this.position.x + this.width / 2 - this.gameLogic.char.maxSpeed) {
            ctx.drawImage(image, imageProportions.width / 2, 0, this.width, this.height, this.position.x, this.position.y, imageProportions.width / 2, imageProportions.height);
        }
    }
    update(deltaTime) {
        if (!this.isNpc && !this.initalized) {
            this.initializeInventory();
        }
        if (!deltaTime) return;
    }
    moveLeft() {
        this.position.x += (this.speed = - this.maxSpeed);
        this.lastDirection = lastDirection.Left;
    }
    moveRight() {
        this.position.x += (this.speed = this.maxSpeed);
        this.lastDirection = lastDirection.Right;
    }
    initializeInventory() {
        this.inventory = new inventory(this.gameLogic, document.getElementById("inventoryImg"));
        this.initalized = true;
    }
}

