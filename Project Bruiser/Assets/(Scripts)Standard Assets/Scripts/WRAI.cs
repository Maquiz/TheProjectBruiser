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
	
	void Start () {
		theBrain = GameObject.Find("Brain") as GameObject;
		brainScript = theBrain.GetComponent("Brain") as Brain;
		hasBall = 0;
		//theBrain = GameObject.Find("Brain").GetComponent("Brain") as Brain;
		routeNum = 0;	
	}
	
	// Update is called once per frame+
	void Update () {
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
			print("We have the ball");
			//theBrain.ballCarrier = "WR";
			//print(theBrain.ballCarrier);
			//WaitForSeconds(5);
			GetComponent<NavMeshAgent>().destination = Endzone.position;
			//Application.LoadLevel("Bruiser1");
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
			print ("Route 0 collision");
			routeNum +=1;
		}
		if(collision.gameObject.name == route2.name)
		{
			print ("Route 0 collision");
			routeNum +=1;
		}
		/*if(collision.gameObject.tag == routePoint){
			routeNum++;
		}*/
	}
void OnTriggerEnter(Collider theCollider){
		if(theCollider.gameObject.name ==endzoneName ){
			brainScript.score0 += 6;
		}
		/*if(collider.gameObject.name == route.name){
			routeNum += 1;
		}*/
	}
	
}
