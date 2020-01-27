export default class Quest {
    constructor(gameLogic, dialogue, completeDialogue, questItem, npc, questReward) {
        this.gameWidth = gameLogic.gameWidth;
        this.gameHeight = gameLogic.gameHeight;
        this.gameLogic = gameLogic;
        this.position = { x: 0, y: 0 };
        this.dialogue = dialogue;
        this.completeDialogue = completeDialogue;
        this.questItem = questItem;
        this.questReward = questReward;
        this.npc = npc;
    }

    update(deltaTime) {
        if (!deltaTime) return;
    }

    draw(ctx) {
        if (this.npc != undefined) {
            this.characterDialogue(ctx, this.dialogue, this.completeDialogue, this.questItem, this.npc);
        }
    }

    characterDialogue(ctx, dialogue, completeDialogue, questItem, npc) {
        ctx.globalAlpha = 0.4;
        ctx.fillStyle = "#FFFFFF";
        ctx.fillRect(npc.position.x - npc.width / 2, npc.position.y - 70, 300, 60);
        ctx.fillStyle = "#000000";
        ctx.globalAlpha = 1.0;
        if (!questItem.isRetrieved) {
            ctx.fillText(dialogue, npc.position.x - npc.width / 2, npc.position.y - 40);
        }
        else {
            ctx.fillText(completeDialogue, npc.position.x - npc.width / 2, npc.position.y - 40);
        }
    }
    correctQuestItem(equippedItem) {
        if (this.questItem.itemModel == equippedItem.itemModel && this.questItem.itemType == equippedItem.itemType && this.questItem.itemName == equippedItem.itemName) {
            this.gameLogic.char.inventory.inventoryItems.push(this.questReward);
            return true;
        }
        else return false;
    }
}