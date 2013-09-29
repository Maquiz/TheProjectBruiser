using UnityEngine;
using System.Collections;

public class routeLife : MonoBehaviour {
	private string WR;

	// Use this for initialization
	void Start () {
		WR = "Blocker";		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == WR){
			Destroy(gameObject);
			print("WRHIT");
		}
	}

}	