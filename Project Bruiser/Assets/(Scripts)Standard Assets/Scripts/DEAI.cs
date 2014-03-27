using UnityEngine;
using System.Collections;

public class DEAI : MonoBehaviour {
	public Transform persuit;
	private int hasBall;
	public string football;
	public string blocker;
	private GameObject theBrain;
	private Brain brainScript;
	private GameObject WR;
	private WRAI persuitHasBall;
	private GameObject QB;
	private throwBall persuitSack;
	//private QB persuitHasBall;
	private int persuitHasBallInt;
	private int sackHasBallInt;
	public int isBlitzing;
	public Transform brainPersuit;
	
	// Use this for initialization
	void Start () {
		theBrain = GameObject.Find("Brain") as GameObject;
		brainScript = theBrain.GetComponent("Brain") as Brain;
		
		QB = GameObject.Find("QB") as GameObject;
		persuitSack = QB.GetComponent("Throw Ball") as throwBall;
		//sackHasBallInt = brainScript.getQBBall();

		//WR = GameObject.Find(persuit.name) as GameObject;
		//persuitHasBall = WR.GetComponent("WRAI") as WRAI;

		hasBall = 0;
		persuitHasBallInt = 0;


	
	}
	
	// Update is called once per frame
	void Update () {
		if(brainScript.isHiked() == 1){
			GetComponent<NavMeshAgent>().destination = persuit.position;//persuitHasBall.getFowardTransform().position;
			GetComponent<NavMeshAgent>().radius = 0;
			GetComponent<NavMeshAgent>().speed = 12f;
		}
		persuitHasBall = GameObject.Find(persuit.name).GetComponent("WRAI") as WRAI;
		if(persuitHasBall != null){ //only under certain cirumstances check it if its null dont even try
			persuitHasBallInt = persuitHasBall.hasBall;
		}
		persuitSack = GameObject.Find(persuit.name).GetComponent("Throw Ball") as throwBall;
		if(persuitSack != null){
			sackHasBallInt = persuitSack.hasBall;
		}
		switch(brainScript.getStateInt()){
		case 0:
			persuitHasBallInt = 0;
			break;
		case 1:
			persuit  =  brainScript.getDefensivePersuit();
			persuitHasBallInt = 1;
			break;
			
		} 
		if (hasBall == 1){
			print("they have the ball");
			//brainScript.nextDown();
		//	theBrain.ballCarrier = "DE";
			//print(theBrain.ballCarrier);
		}
		sackHasBallInt = brainScript.getQBBall();
	}
	void OnCollisionEnter(Collision collision) {
		if((collision.gameObject.tag == football)){
			GameObject footballDestructive;
			footballDestructive = collision.gameObject;
			print("They got collision");
			brainScript.score1 += 1;
			hasBall = 1;
			Destroy(footballDestructive);
			brainScript.setHiked(0);
			//brainScript.nextDown();
			Application.LoadLevel("Bruiser1");
		}
		if((collision.gameObject.name == persuit.name) &&  (brainScript.getQBBall() ==  1) && (blitzing() == 1)){
			brainScript.setEndPos(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
			print (brainScript.getEndPos());
			print ("QB SACKED I HIT" + persuit.name + " " + this.name);
			brainScript.score1 += 1;
			brainScript.setHiked(0);
			brainScript.nextDown();
			brainScript.setStateInt(0);
			persuitHasBallInt = 0;
			Application.LoadLevel("Bruiser1");
		}
		if((collision.gameObject.name == persuit.name) && persuitHasBallInt == 1) {
			brainScript.setEndPos(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
			print (brainScript.getEndPos());
			print("I DIDNT SACK THE QB I Hit" + persuit.name);
			brainScript.score1 += 1;
			brainScript.setHiked(0);
			brainScript.nextDown();
			brainScript.setStateInt(0);
			persuitHasBallInt = 0;
			Application.LoadLevel("Bruiser1");
		}
		if(collision.gameObject. tag == blocker){
			
		}
	}
		public void blitzerCall(int blitz){
			if(blitz == 0){
				isBlitzing = 0;
			}
			if(blitz == 1){
				isBlitzing = 1;
			}
		}
		public int blitzing(){
			return isBlitzing;
		}

}
