using UnityEngine;
using System.Collections;

public class throwBall : MonoBehaviour {

public GameObject theFootballPrefab;
public Transform centerThrow;
public Transform leftThrow;
public Transform rightThrow;
public Transform frontCenterThrow;
public Transform frontLeftThrow;
public Transform frontRightThrow;
public Transform backCenterThrow;
public Transform backLeftThrow;
public Transform backRightThrow;
public tsg_PropulsionPhysics physicsScript ;
public int hasBall;
private int random = 0;
private GameObject theBrain;
private Brain brainScript;
public string endzoneName;

void Start(){
	physicsScript = gameObject.GetComponent("tsg_PropulsionPhysics")as tsg_PropulsionPhysics;
	hasBall = 1;
	theBrain = GameObject.Find("Brain") as GameObject;
	brainScript = theBrain.GetComponent("Brain") as Brain;

}

void Update () {
	GameObject theFootball =  null;
	if(Input.GetKeyDown(KeyCode.Alpha1)){
			random = 0;
			print("short");
		}
	if(Input.GetKeyDown(KeyCode.Alpha2)){
			random = 1;
			print("medium");
		}
	if(Input.GetKeyDown(KeyCode.Alpha3)){
			random = 2;
			print("long");
		};
		
	
if(hasBall == 1){
	if(Input.GetMouseButtonUp(0)){
		switch(random){
				case 0:
					print("Left");
					physicsScript.target = leftThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;
				case 1:
					print("Center");
					physicsScript.target = centerThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;
				case 2:
					print("Right");
					physicsScript.target = rightThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;/*
				case 3:
					print("FLeft");
					physicsScript.target = frontLeftThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;
				case 2:
					print("FCenter");
					physicsScript.target = frontCenterThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;/*
				case 5:
					print("FRight");
					physicsScript.target = frontRightThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;
				case 6:
					print("BLeft");
					physicsScript.target = backLeftThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;
				case 3:
					print("BCenter");
					physicsScript.target = backCenterThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;
			/*	case 8:
					print("BRight");
					physicsScript.target = backRightThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;	*/		
				}
			}
		}
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

