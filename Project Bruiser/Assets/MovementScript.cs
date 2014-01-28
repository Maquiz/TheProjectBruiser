using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	private GameObject theBrain;
	private Brain brainScript;
	private float thisX,thisY,thisZ; //Offensive 3DVector
	private Vector3 thisVector;
	
	// Use this for initialization
	void Start () {
		
		theBrain = GameObject.Find("Brain") as GameObject; //Reference to Brain Game Object
		brainScript = theBrain.GetComponent("Brain") as Brain; //Reference to Brain.cs
		
		//thisX = gameObject.transform.position.x;//Initiate X Value
		//thisY = gameObject.transform.position.y;//Initiate Y Value
	//	thisZ = gameObject.transform.position.z;//Initiate Z Value
		//thisVector 
		thisX = 241f;
		thisY = brainScript.getEndPos().y;
		thisZ = brainScript.getEndPos().z;
		print ( thisX + " " + thisY + " " + thisZ);
		SetOffeniveSpot(thisX,thisY,thisZ);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void updateOffensiveSpot(){
		thisVector = new Vector3(thisX,thisY,thisZ);
	}
	
	public Vector3 GetOffeniveSpot(){
		return thisVector;
	}
	
	public void SetOffeniveSpot(float x, float y, float z){
		transform.position = new Vector3(x,y,z);
		print (gameObject.transform.position);
		//this.transform.position.Set(x,y,z);
		//thisVector = new Vector3(x,y,z);
	}
}
