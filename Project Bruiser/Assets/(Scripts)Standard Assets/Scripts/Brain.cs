using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Brain : MonoBehaviour {
	public string ballCarrier;
	public int[] offenseVector; 
	public int[] defenseVector;
	public int nextTeamSelect;
	public int offenseSize;
	public int score0;
	public int score1;
	// Use this for initialization
	void Start () {
		nextTeamSelect = 0;
		offenseSize = 6;
		defenseVector = new int[offenseSize];
		offenseVector = new int[offenseSize];
		for(int x = 0; x<offenseSize;x++){
			offenseVector[x] =  0;
			defenseVector[x] = 0;
		}
		DontDestroyOnLoad(gameObject);
		Application.LoadLevel("MainMenuScene");
	}
	
	// Update is called once per frame
	void Update () {
		if(score0 >= 10){
			print("Offense Wins!");
			score0 = 0;
			score1 = 0;
			Application.LoadLevel("Bruiser1");
		}
		if(score1 >= 10){
			print("Defense Wins!");
			score0 = 0;
			score1 = 0;
			Application.LoadLevel("Bruiser1");
		}
	
	}
	void changeBallCarrier(string newBallCarrier){
		ballCarrier = newBallCarrier;
		
	}
	
}
