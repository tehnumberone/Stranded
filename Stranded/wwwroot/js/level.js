import collisionDetection from "./collisionDetection.js"; 

export default class Level {
    constructor(gameLogic, levelBackgroundImg, currentLevel, allItems, character) {
        this.character = character;
        this.gameLogic = gameLogic;
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;

        this.width = 800;
        this.height = 800;
        this.allItems = allItems;
        this.position =
        {
            x: 0,
            y: 0
        };
        this.levelBackgroundImg = levelBackgroundImg;
        this.initalizedItems = false;
        this.currentLevel = currentLevel;
        this.collisionDetection = new collisionDetection(this.character);
    }

    draw(ctx) {
       ctx.drawImage(this.levelBackgroundImg, this.position.x, this.position.y, this.width, this.height);
       if(this.allItems !== undefined){
            if(this.currentLevel === 1 && this.allItems.length > 0 && !this.allItems[1].pickedUp){
                this.allItems[1].draw(ctx);
            }
       }
    }
    update(deltaTime) {
        if(this.collisionDetection.isColliding(this.allItems[1])){
            this.allItems[1].displayItem = false;
            this.allItems[1].position.x = -50;
            if(this.character.inventory.inventoryItems == undefined){
                this.character.inventory.inventoryItems = [];
            }
            this.character.inventory.inventoryItems.push(this.allItems[1]);
            var tempList = [];
            this.character.inventory.inventoryItems.forEach(element => tempList.push(element.itemModel.src));
            window.InventoryItems = tempList;
        }
    }
}