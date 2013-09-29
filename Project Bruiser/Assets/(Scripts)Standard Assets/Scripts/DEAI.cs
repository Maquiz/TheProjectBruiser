using UnityEngine;
using System.Collections;

public class DEAI : MonoBehaviour {
	public Transform persuit;
	private int hasBall;
	public string football;
	public string blocker;
	private GameObject theBrain;
	private Brain brainScript;
	private WRAI persuitHasBall;
	private GameObject QB;
	private throwBall persuitSack;
	//private QB persuitHasBall;
	private int persuitHasBallInt;
	private int sackHasBallInt;
	
	// Use this for initialization
	void Start () {
		theBrain = GameObject.Find("Brain") as GameObject;
		brainScript = theBrain.GetComponent("Brain") as Brain;
		
		QB = GameObject.Find("QB") as GameObject;
		persuitSack = QB.GetComponent("Throw Ball") as throwBall;
		
		hasBall = 0;
		persuitHasBallInt = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<NavMeshAgent>().destination = persuit.position;
		persuitHasBall = GameObject.Find(persuit.name).GetComponent("WRAI") as WRAI;
		if(persuitHasBall != null){ //only under certain cirumstances check it if its null dont even try
			persuitHasBallInt = persuitHasBall.hasBall;
		}
		if(persuitSack != null){
			sackHasBallInt = persuitSack.hasBall;
		}
		if (hasBall == 1){
			print("they have the ball");
		//	theBrain.ballCarrier = "DE";
			//print(theBrain.ballCarrier);
		}
	}
	void OnCollisionEnter(Collision collision) {
		if((collision.gameObject.tag == football)){
			GameObject footballDestructive;
			footballDestructive = collision.gameObject;
			print("They got collision");
			brainScript.score1 += 1;
			hasBall = 1;
			Destroy(footballDestructive);
			Application.LoadLevel("Bruiser1");
		}
		if((collision.gameObject.tag == persuit.tag) &&((persuitHasBallInt == 1) || (sackHasBallInt ==  1))){
			brainScript.score1 += 1;
			Application.LoadLevel("Bruiser1");
		}
		if(collision.gameObject. tag == blocker){
			
		}
	}
	
}
