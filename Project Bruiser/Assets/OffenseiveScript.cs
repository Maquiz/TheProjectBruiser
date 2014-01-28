using UnityEngine;
using System.Collections;

public class OffenseiveScript : MonoBehaviour {

	private GameObject theBrain;
	private Brain brainScript;
	private float thisX,thisY,thisZ; //Offensive 3DVector
	private Vector3 thisVector;

	// Use this for initialization
	void Start () {

		theBrain = GameObject.Find("Brain") as GameObject; //Reference to Brain Game Object
		brainScript = theBrain.GetComponent("Brain") as Brain; //Reference to Brain.cs

		thisX = gameObject.transform.position.x;//Initiate X Value
		thisY = gameObject.transform.position.y;//Initiate Y Value
		thisZ = gameObject.transform.position.z;//Initiate Z Value
		//thisVector 

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 GetOffeniveSpot(){
		return thisVector;
	}

	public void SetOffeniveSpot(int x, int y, int z){
		//thisVector = Vector3()
	}
}
