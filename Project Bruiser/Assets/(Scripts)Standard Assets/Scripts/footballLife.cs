using UnityEngine;
using System.Collections;

public class footballLife : MonoBehaviour {
	
public float lifeSpan;
public string terrainTag;
public string defenseTag;
private GameObject theScore;
private  Brain brainScript1;
void Start(){
		theScore = GameObject.Find("Brain") as GameObject;
		brainScript1 = theScore.GetComponent("Brain") as Brain;
		
	}
	
void Update () {
	lifeSpan = 2;
	//Destroy(gameObject,lifeSpan);
}

void OnCollisionEnter(Collision collision){
	if(collision.gameObject.tag == terrainTag){
		brainScript1.score1 +=1;
		print("we hit the ground");
		Application.LoadLevel("Bruiser1");
	}
	if(collision.gameObject.tag == defenseTag){
		print("DEFENSE!");
		//Application.LoadLevel("Bruiser1");
	}
}
}