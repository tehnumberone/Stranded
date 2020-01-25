import collisionDetection from "./collisionDetection.js";

export default class Level {
    constructor(gameLogic, levelBackgroundImg, currentLevel, levelItems) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;

        this.width = 800;
        this.height = 800;
        this.levelItems = levelItems;
        this.position =
            {
                x: 0,
                y: 0
            };
        this.levelBackgroundImg = levelBackgroundImg;
        this.currentLevel = currentLevel;
    }

    draw(ctx) {
        ctx.drawImage(this.levelBackgroundImg, this.position.x, this.position.y, this.width, this.height); //background of level
        if (this.levelItems != undefined) {//draws all items of the level.
            this.levelItems.forEach((object) =>
                object.draw(ctx));
        }
    }
    update(deltaTime) {

    }
}