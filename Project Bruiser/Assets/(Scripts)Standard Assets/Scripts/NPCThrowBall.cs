using UnityEngine;
using System.Collections;

public class NPCThrowBall : MonoBehaviour {

public GameObject theFootballPrefab;
public Transform centerThrow;
/*public Transform leftThrow;
public Transform rightThrow;
public Transform frontCenterThrow;
public Transform frontLeftThrow;
public Transform frontRightThrow;
public Transform backCenterThrow;
public Transform backLeftThrow;
public Transform backRightThrow;*/
public tsg_PropulsionPhysics physicsScript ;
private int hasBall;

void Start(){
	physicsScript = gameObject.GetComponent("tsg_PropulsionPhysics")as tsg_PropulsionPhysics;
	hasBall = 1;

}

void Update () {
	GameObject theFootball =  null;
	int random = Random.Range(1,1);
if(hasBall == 1){
	
	//if(Input.GetMouseButtonUp(0)){
		//switch(random){
				/*case 0:
					print("Left");
					physicsScript.target = leftThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;*/
		//		case 1:
					print("Center");
					physicsScript.target = centerThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position*2,transform.rotation) as GameObject;
					hasBall = 0;
		//			break;
			/*	case 2:
					print("Right");
					physicsScript.target = rightThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;
				case 3:
					print("FLeft");
					physicsScript.target = frontLeftThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;
				case 4:
					print("FCenter");
					physicsScript.target = frontCenterThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;
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
				case 7:
					print("BCenter");
					physicsScript.target = backCenterThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;
				case 8:
					print("BRight");
					physicsScript.target = backRightThrow;
					theFootball = Instantiate(theFootballPrefab,transform.position,transform.rotation) as GameObject;
					hasBall = 0;
					break;		*/	
			//	}
		//	}
		}
	}
}

