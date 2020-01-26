export default class inventory {
    constructor(gameLogic, image) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;
        this.gameLogic = gameLogic;
        this.width = 800;
        this.height = 800;
        this.defaultXpos = 300;
        this.defaultYpos = 50;
        this.defaultSize = 55;
        this.inventorySize = {
            w: 238,
            h: 475
        }
        this.maxSlots = 28 - 1;
        this.maxRows = 7;
        this.allRows = [];
        this.position =
            {
                x: this.gameWidth / 2 - this.width / 2,
                y: this.gameHeight / 2 - this.height / 2
            };
        this.image = image;
        this.inventoryItems = [];
    }

    update(deltaTime) {
        if (this.inventoryItems.length > 0) {
        }
    }

    draw(ctx) {
        this.image.style.opacity = "0.5";
        ctx.drawImage(this.image, this.defaultXpos, this.defaultYpos, this.inventorySize.w, this.inventorySize.h);
        if (this.inventoryItems != undefined) {
            this.inventoryItemDrawPosition(ctx, this.inventoryItems);
        }
        this.inventoryUI(ctx);
    }
    inventoryItemDrawPosition(ctx, inventoryItems) {
        var row = [];
        var size = this.defaultSize;
        var currentXpos = this.defaultXpos;
        var currentYpos = this.defaultYpos;
        this.allRows = [];

        for (var a = 1; a < inventoryItems.length + 1; a++) {
            row.push(inventoryItems[a]);
            if (a % 4 === 0 && a != 0) {
                this.allRows.push(row);
                row = [];
            }
        }
        if (row.length > 0) {
            this.allRows.push(row);
        }
        var amountOfRows = this.allRows.length;

        for (var b = 0; b < amountOfRows; b++) {
            for (var i = 0; i < this.allRows[b].length; i++) {
                if (i > 0) {
                    currentXpos = currentXpos + (size + 5);
                }
                var currentItem = i + (b * 4);//4 here is the max in a single row, b stands for current row
                ctx.drawImage(inventoryItems[currentItem].itemModel, currentXpos, currentYpos, size, size);
                inventoryItems[currentItem].width = size;
                inventoryItems[currentItem].height = size;
                inventoryItems[currentItem].position.x = currentXpos;
                inventoryItems[currentItem].position.y = currentYpos;
            }
            currentXpos = this.defaultXpos;
            currentYpos = currentYpos + (size + 4);
        }
    }

    inventoryUI(ctx) {
        ctx.fillStyle = 'rgba(0,0,0,1)';
        ctx.rect(this.defaultXpos, this.defaultYpos, this.inventorySize.w, this.inventorySize.h);
        ctx.stroke();
    }

}