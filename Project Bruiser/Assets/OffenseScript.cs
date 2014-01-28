using UnityEngine;
using System.Collections;

public class OffenseScript : MonoBehaviour {
	public int hasBall;
	private GameObject theBrain;
	private Brain brainScript;
	public string football;

	// Use this for initialization
	void Start () {
		theBrain = GameObject.Find("Brain") as GameObject;
		brainScript = theBrain.GetComponent("Brain") as Brain;
		hasBall = 0;
		//theBrain = GameObject.Find("Brain").GetComponent("Brain") as Brain
	}
	// Update is called once per frame
	void Update () {
	
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
	}
}
