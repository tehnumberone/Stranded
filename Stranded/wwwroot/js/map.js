export default class Map {
    constructor(gameLogic, mapImage) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;

        this.maxSpeed = 25;
        this.speed = 0;
        this.mapImage = mapImage;
    }
    draw(ctx) {
        ctx.drawImage(this.mapImage, 0, 0, this.gameWidth, this.gameHeight);
    }
    update(deltaTime) {
        if (!deltaTime) return;
    }
}