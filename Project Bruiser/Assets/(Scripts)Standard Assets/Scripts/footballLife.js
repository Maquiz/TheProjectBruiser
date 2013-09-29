var lifeSpan : float;
public var terrainTag;
function Update () {
	lifeSpan = 2.0;
	//Destroy(gameObject,lifeSpan);
}

function OnCollisionEnter(collision :  Collision){
	if(collision.gameObject.tag == terrainTag){
		Application.LoadLevel("Bruiser1");
	}

}