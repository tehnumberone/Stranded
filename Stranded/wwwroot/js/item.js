export default class Item {
    constructor(gameLogic, itemModel, itemName, itemType) {
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
        this.itemType = itemType;
        this.itemName = itemName;
        this.itemTypes = {
            Tool: "Tool",
            Food: "Food",
            Medical: "Medical",
            Weapon: "Weapon",
            Armour: "Armour"
        };
        this.isRetrieved = false;
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