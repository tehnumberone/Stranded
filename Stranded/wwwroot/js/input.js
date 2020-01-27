export default class InputHandler {
    constructor(character, gameLogic) {
        this.gameLogic = gameLogic;
        document.addEventListener("keydown",//key down event
            event => {
                switch (event.keyCode) {
                    case 65://left
                        if (this.gameLogic.gameState == 0) {
                            character.moveLeft();
                        }
                        break;
                    case 68://right
                        if (this.gameLogic.gameState == 0) {
                            character.moveRight();
                        }
                        break;
                    /*case 87://up
                        character.moveUp();
                        break;
                    
                    case 83://down
                        character.moveDown();
                        break;
                        */
                    case 73: //i button
                        if (this.gameLogic.gameState == 1 || this.gameLogic.gameState == 0) {
                            gameLogic.openInventory();
                            break;
                        }
                    case 69:
                        if (this.gameLogic.gameState == 0) {
                            gameLogic.interact = true;
                            break;
                        }
                    //case 67: //c button
                    //    stats.characterStats();
                    //    break;
                    //case 109: //m button
                    //    gameLogic.saveGame();
                    //    break;
                }
            });
    }
}