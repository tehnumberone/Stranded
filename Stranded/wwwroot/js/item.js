const itemTypes = {
    Tool: 1,
    Food: 2,
    Medical: 3,
    Weapon: 4,
    Armour: 5
}
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
        this.itemType;
        this.itemName;
    }
    update(deltaTime) {
        if (!deltaTime) return;
    }

    draw(ctx) {
        if (this.itemModel != undefined) {
            ctx.drawImage(this.itemModel, this.position.x, this.position.y, this.width, this.height);
        }
    }
}