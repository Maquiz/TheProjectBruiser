using UnityEngine;
using System.Collections;

public class WRAI : MonoBehaviour {
	
	public Transform route;
	public Transform route1;
	public Transform route2;
	private Transform routePoint;
	public Transform Endzone;
	public string endzoneName;
	public string football;
	public int hasBall;
	private GameObject theBrain;
	private Brain brainScript;
	private int routeNum;
	private Transform FowardTransform;
	
	void Start () {
		theBrain = GameObject.Find("Brain") as GameObject;
		brainScript = theBrain.GetComponent("Brain") as Brain;
		hasBall = 0;
		//theBrain = GameObject.Find("Brain").GetComponent("Brain") as Brain;
		routeNum = 0;	
	}
	
	// Update is called once per frame+
	void Update () {
		if(brainScript.isHiked() == 1){
			GetComponent<NavMeshAgent>().speed = 12f;
			if(routeNum == 0){
				GetComponent<NavMeshAgent>().destination = route.position;
				
			}
			
			if(routeNum == 1){
				GetComponent<NavMeshAgent>().destination = route1.position;
				
			}//	routePoint = route1.tag;
			if(routeNum == 2){
				GetComponent<NavMeshAgent>().destination = route2.position;
			}
			if(routeNum == 3){
				GetComponent<NavMeshAgent>().destination = Endzone.position;
				
			//	routePoint = route2.tag;
			}
			if (hasBall == 1){
			//	print(this.rigidbody.position.z); //Checking Z Position for Ball Carrier
				//theBrain.ballCarrier = "WR";
				//print(theBrain.ballCarrier);
				//WaitForSeconds(5);
				brainScript.setDefensivePersuit(gameObject.transform);
				brainScript.setStateInt(1);
				GetComponent<NavMeshAgent>().destination = Endzone.position;
				//Application.LoadLevel("Bruiser1");
				if((gameObject.transform.position.z >= 467 && gameObject.transform.position.z <= 507)
				   &&(gameObject.transform.position.x >= 174 && gameObject.transform.position.x <= 311)){
					brainScript.score0 += 6;
					print("TouchDown!!!!");
					brainScript.setHiked(0);
					Application.LoadLevel("Bruiser1");
				}
			}
		}
			
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == football){
			GameObject footballDestructive;
			footballDestructive = collision.gameObject;
			print("we got collision");
			hasBall = 1;
			brainScript.score0 +=2;
			Destroy(footballDestructive);
		}
		/*if(collision.gameObject.name == endzoneName){
			brainScript.score0 += 6;
			Application.LoadLevel("Bruiser1");
			
		}*/
		if(collision.gameObject.name == route.name)
		{
			print ("Route 0 collision");
			routeNum +=1;
		}
		if(collision.gameObject.name == route1.name)
		{
			print ("Route 1 collision");
			routeNum +=1;
		}
		if(collision.gameObject.name == route2.name)
		{
			print ("Route 2 collision");
			routeNum +=1;
		}
		/*if(collision.gameObject.tag == routePoint){
			routeNum++;
		}*/
	}
void OnTriggerEnter(Collider theCollider){
		print(theCollider.name);
		if(theCollider.gameObject.name == endzoneName ){
			brainScript.score0 += 6;
		}
		/*if(collider.gameObject.name == route.name){
			routeNum += 1;
		}*/
	}

	public void setFowardTransform(Transform thisTransform){
		FowardTransform = thisTransform;
	}

	public Transform getFowardTransform(){
		return FowardTransform;
	}
}
