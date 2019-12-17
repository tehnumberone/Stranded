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
        ctx.drawImage(this.charmodel, this.position.x, this.position.y, this.width, this.height);
    }
    update(deltaTime) {
        if (!deltaTime) return;
        if (this.position.x < 0) {
            this.position.x = 0;
        }
        if (this.position.x > this.gameWidth - this.width) {
            this.position.x = this.gameWidth - this.width;
        }
        if (this.position.y < 0) {
            this.position.y = 0;
        }
        if (this.position.y > this.gameHeight - this.height) {
            this.position.y = this.gameHeight - this.height;
        }
    }
    moveLeft() {
        this.position.x += (this.speed = -this.maxSpeed);

    }
    moveRight() {
        this.position.x += (this.speed = this.maxSpeed);
    }
    moveUp() {
        this.position.y += (this.speed = -this.maxSpeed);
    }
    moveDown() {
        this.position.y += (this.speed = this.maxSpeed);
    }
}

