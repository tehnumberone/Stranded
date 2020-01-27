export default class collisionDetection {
    constructor(maxLevel) {
        this.maxLevel = maxLevel;
    }
    update(deltaTime) {
        if (!deltaTime) return;
    }

    exceededBorder(c) { // c is character
        if (c.position.x < 0 && c.currentLevel > 1) {//check left side.
            c.position.x = c.gameWidth - (c.width * 2);
            c.previousLevel = true;
        }
        if (c.position.x < 0 && c.currentLevel === 1) {//check left side.
            c.position.x = 0;
            c.previousLevel = false;
        }
        if (c.position.x > c.gameWidth - c.width && c.currentLevel < this.maxLevel) {//check right side
            c.position.x = c.width;
            c.nextLevel = true;
        }
        if (c.position.x > c.gameWidth - c.width && c.currentLevel === this.maxLevel) {//check right side
            c.position.x = c.gameWidth - c.width;
            c.nextLevel = false;
        }
    }

    isColliding(c, gameObject) { // c is character
        if (c.position.x == gameObject.position.x) {//check if on same tile
            return true;
        }
        else if (c.position.x <= gameObject.position.x + gameObject.width - (c.width / 2) && // check if char went over the tile , but is still within the gameObject bounds
            c.position.x >= gameObject.position.x - (c.width / 2)) {
            return true;
        }
        else return false;
    }
}