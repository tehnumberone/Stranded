export default class inventory {
    constructor(gameLogic, image) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;

        this.width = 650;
        this.height = 650;

        this.position =
            {
                x: this.gameWidth / 2 - this.width / 2,
                y: this.gameHeight / 2 - this.height / 2
            };
        this.image = image;
    }

    update(deltaTime) {

    }

    draw(ctx) {
        ctx.drawImage(this.image, this.position.x, this.position.y, this.width, this.height);
    }
}