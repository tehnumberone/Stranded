export default class mainMenu {

    constructor(gameLogic, image, canvas) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;
        this.canvas = canvas;
        this.width = 800;
        this.height = 800;
        this.rect = {
            x: this.gameWidth - this.gameWidth * 0.9,
            y: this.gameHeight - this.gameHeight * 0.22,
            w: 75,
            h: 30
        };
        this.playbutton = {
            x: this.rect.x,
            y: this.rect.y + 16,
            text: "Play",
            font: "30px Arial"
        };
        this.position = {
            x: this.gameWidth / 2 - this.width / 2,
            y: this.gameHeight / 2 - this.height / 2
        };
        this.image = image;
    }

    update(deltaTime) {
    }

    draw(ctx) {
        this.ctx = ctx; //draw mainmenu
        ctx.drawImage(this.image, this.position.x, this.position.y, this.width, this.height);
        this.drawText(ctx, this.playbutton);
    }

    drawText(ctx, element) {
        ctx.font = element.font;
        ctx.fillText(element.text, element.x, element.y);
    }
}

