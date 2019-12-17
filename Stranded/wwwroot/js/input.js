export default class InputHandler {
    constructor(character, gameLogic) {
        document.addEventListener("keydown",//key down event
            event => {
                switch (event.keyCode) {
                    case 65://left
                        character.moveLeft();
                        break;
                    case 87://up
                        character.moveUp();
                        break;
                    case 68://right
                        character.moveRight();
                        break;
                    case 83://down
                        character.moveDown();
                        break;
                    case 73: //i button
                        gameLogic.openInventory();
                        break;
                    //case 67: //c button
                    //    stats.characterStats();
                    //    break;
                }
            });
    }
}