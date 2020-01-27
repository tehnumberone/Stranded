export default class Level {
    constructor(gameLogic, levelBackgroundImg, currentLevel, levelItems) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;
        this.gameLogic = gameLogic;
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
        this.npcs = [];
        this.quests = [];
        this.dialogues = [];//max characters in a line is 47. if you add more than 47, it goes over the border.
        this.dialoguePosition = {
            x: this.gameWidth / 3,
            y: this.gameHeight / 3
        };
        this.toolTip = false;
    }

    draw(ctx) {
        ctx.drawImage(this.levelBackgroundImg, this.position.x, this.position.y, this.width, this.height); //background of level
        if (this.levelItems != undefined) {                                                                //draws all items of the level.
            this.levelItems.forEach((object) =>
                object.draw(ctx));
        }
        if (this.containsNpc()) {                                                                          //draws all npcs of the level.
            this.npcs.forEach((object) =>
                object.draw(ctx));
        }
        if (this.containsQuest()) {                                                                        //draws all quests of the level.
            this.quests.forEach((object) =>
                object.draw(ctx));
        }
        if (this.toolTip && this.dialogues.length > 0) {
            this.toolTipDialogue(this.dialogues, this.dialoguePosition, ctx);
        }
    }
    update(deltaTime) {
        if (!deltaTime) return;
        if (this.containsNpc() && this.containsQuest() && this.gameLogic.char.equippedItem != null) {
            if (this.checkIfCharCloseToNPC(this.gameLogic.char)) {
                for (var i = 0; i < this.quests.length; i++) {
                    if (this.quests[i].correctQuestItem(this.gameLogic.char.equippedItem)) {
                        this.quests[i].questItem.isRetrieved = true;
                        var char = this.gameLogic.char;
                        char.inventory.inventoryItems
                        char.inventory.inventoryItems = char.inventory.inventoryItems.filter(function (e) {
                            return e !== char.equippedItem
                        });
                        char.equippedItem = null;
                        char.itemEquipped = false;
                        this.toolTip = false;
                    }
                }
            }
        }
    }

    containsQuest() {
        if (this.quests.length === 0) {
            return false;
        }
        else return true;
    }
    containsNpc() {
        if (this.npcs.length === 0) {
            return false;
        }
        else return true;
    }
    checkIfCharCloseToNPC(character) {
        if (this.gameLogic.npcCollision(character)) {
            return true;
        }
        else return false;
    }
    toolTipDialogue(dialogues, position, ctx) {
        ctx.globalAlpha = 0.4;
        ctx.fillStyle = "#FFFFFF";
        ctx.fillRect(position.x - 20, position.y - 25, 350, 30 * dialogues.length);
        ctx.fillStyle = "#000000";
        ctx.globalAlpha = 1.0;
        for (var i = 0; i < dialogues.length; i++) {
            ctx.fillText(dialogues[i], position.x, position.y + i * 25);
        }

    }
}