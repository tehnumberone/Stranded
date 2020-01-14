export default class Item {
    constructor(gameLogic, itemModel) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;

        this.width = 50;
        this.height = 50;

        this.position =
        {
            x: this.gameWidth / 2,
            y: this.gameHeight - this.height - 190
        };
        this.itemModel = itemModel;
        this.displayItem = true;
        this.pickedUp = false;
    }
    update(deltaTime) {
        if (!deltaTime) return;
    }

    draw(ctx) {
        if(this.itemModel != undefined && this.displayItem){
            ctx.drawImage(this.itemModel, this.position.x, this.position.y, this.width, this.height);}
    }
}