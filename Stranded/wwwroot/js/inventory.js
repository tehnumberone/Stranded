export default class inventory {
    constructor(gameLogic, image) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;

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
        if(this.inventoryItems === undefined){
            this.inventoryItems = [];
        }
    }

    draw(ctx) {
        //console.log(this.inventoryItems.length);
        ctx.drawImage(this.image, this.position.x, this.position.y, this.width, this.height);
        if (this.inventoryItems !== undefined || this.inventoryItems.length > 0) {
            for (var i = 0; i < this.inventoryItems.length; i++) {
                var size = 75;
                if (i > 0) {
                    var currentYpos = this.gameHeight / 4 + (i * 75);
                }
                else{
                    var currentYpos = this.gameHeight / 4 - size;
                }
                ctx.drawImage(this.inventoryItems[i].itemModel, this.gameWidth / 2 -(size / 2), currentYpos , size, size);
            }
        }
    }
}