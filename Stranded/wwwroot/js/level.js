export default class Character {
    constructor(gameLogic, charmodel) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;

        this.width = 50;
        this.height = 75;

        this.maxSpeed = 25;
        this.speed = 0;

        this.position =
        {
            x: this.gameWidth / 2 - this.width / 2,
            y: this.gameHeight - this.height - 10
        };
        this.charmodel = charmodel;
    }
    draw(ctx) {
        ctx.drawImage(this.image, this.position.x, this.position.y, this.width, this.height);
    }
    update(deltaTime) {
    }
}