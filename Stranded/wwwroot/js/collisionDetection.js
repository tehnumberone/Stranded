export default class collisionDetection{
	constructor(character)  {
		this.charPosition = character.position;
	}
	update(deltaTime){
        if (!deltaTime) return;
	}

	isColliding(gameObject){
		if(this.charPosition.x == gameObject.position.x){
			return true;
		}
	}
}