export default class inventory {
    constructor(gameLogic, image) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;
        this.gameLogic = gameLogic;
        this.width = 800;
        this.height = 800;

        this.position =
            {
                x: this.gameWidth / 2 - this.width / 2,
                y: this.gameHeight / 2 - this.height / 2
            };
        this.image = image;
        this.inventoryItems = window.InventoryItems;
    }

    update(deltaTime) {
        if (this.inventoryItems === undefined) {
            this.inventoryItems = [];
        }
        if (this.inventoryItems.length > 0) {
        }
    }

    draw(ctx) {
        ctx.drawImage(this.image, this.position.x, this.position.y, this.width, this.height);
        if (this.inventoryItems != undefined) {
            for (var i = 0; i < this.inventoryItems.length; i++) {
                var size = 75;
                if (i > 0) {
                    var currentYpos = this.gameHeight / 4 + (i * 75);
                    this.inventoryItems[i].position.y = currentYpos;
                }
                else {
                    var currentYpos = this.gameHeight / 4 - size;
                    this.inventoryItems[i].position.y = currentYpos;
                }
                this.inventoryItems[i].width = size;
                this.inventoryItems[i].height = size;
                ctx.drawImage(this.inventoryItems[i].itemModel, this.gameWidth / 2 - (size / 2), currentYpos, size, size);
            }
        }
    }

}