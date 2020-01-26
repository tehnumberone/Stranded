export default class Quest {
    constructor(gameLogic, dialogue, completeDialogue, questItem, npc) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;

        this.position = npc.position;
        this.dialogue = dialogue;
        this.completeDialogue = completeDialogue;
        this.questItem = questItem;
    }

    update(deltaTime) {
        if (!deltaTime) return;
    }

    draw(ctx) {
        if (this.itemModel != undefined) {
            ctx.drawImage(this.itemModel, this.position.x, this.position.y, this.width, this.height);
        }
        this.characterDialogue(ctx, this.dialogue, this.completeDialogue, this.questItem, this.position);
    }

    characterDialogue(ctx, dialogue, completeDialogue, position) {
        ctx.fillRect(position.x, position.y - 100, 250, 60);
        if (!this.questItem.isRetrieved) {
            ctx.fillText(dialogue, position.x + 10, position.y - 80);
        }
        else {
            ctx.fillText(completeDialogue, position.x + 10, position.y - 80);
        }
    } 
}