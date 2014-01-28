using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Brain : MonoBehaviour {
	public string ballCarrier;
	public int[] offenseVector; //Team 1 Array
	public int[] defenseVector; //Team 2 Array
	public int nextTeamSelect;
	public int offenseSize;
	public int score0, score1;
	private int ballHiked;
	private int down;
	private int possession;
	private int QBHasBall;
	private Vector3 StartPos,EndPos,FirstDownPos;
	private Transform DefensivePersuit;
	private enum States{
		PAUSE, LIVEBALL, CENTER, HIKED, INTHEAIR, AFTERRECEPTION
	};
	private int stateInt;

	
	void Start () {
		QBSetBall(0);
		setPossession(0);
		setHiked(0);
		nextTeamSelect = 0;
		offenseSize = 6;
		defenseVector = new int[offenseSize];
		offenseVector = new int[offenseSize];
		setEndPos(new Vector3(241.690f,0.72114f,217.356f));
		if(getDown() == 0){
			setDown(1);
		}
		for(int x = 0; x<offenseSize;x++){
			offenseVector[x] =  0;
			defenseVector[x] = 0;
			}
		DontDestroyOnLoad(gameObject);
		Application.LoadLevel("MainMenuScene");
	}

	void Update () {
		if(score0 >= 10){
			print("Offense Wins!");
			score0 = 0;
			score1 = 0;
			setHiked(0);
			Application.LoadLevel("Bruiser1");
		}
		if(score1 >= 10){
			print("Defense Wins!");
			score0 = 0;
			score1 = 0;
			setHiked(0);
			Application.LoadLevel("Bruiser1");
		}
	
	}

	void changeBallCarrier(string newBallCarrier){
		ballCarrier = newBallCarrier;
	}

	public void setHiked(int go){
		if(go == 1){//ball is hiked
			ballHiked = 1;
			print("QB has the ball");
		}
		if(go == 0){//center has the ball
			ballHiked = 0;
			setStateInt(0);
			print("Center has the ball");
		}
	}

	public int isHiked(){
		return ballHiked;
	}

	public void setDown(int downLocal){
		if(downLocal == 1){//1st down
			down = 1;
			print("1st down");
		}
		if(downLocal == 2){//2nd down
			down = 2;
			print("2nd down");
		}
		if(downLocal == 3){//3rd down
			down = 3;
			print("3rd down");
		}
		if(downLocal == 4){//4th down
			down = 4;
			print("4th down");
		}
		if(downLocal >= 5){//Possesion Switch
			possessionSwitch();
			setDown(1);
			down = 1;
		}
	}

	public int getDown(){
		return down;
	}

	public void nextDown(){
		down++;
		setDown(down);
	}

	public void possessionSwitch(){
		if(possession == 0){
			possession = 1;
		}
		 if(possession == 1){
			possession = 0;
		}
	}

	public void setPossession(int possessTeam){
		if(possessTeam == 0){//Team 1 Possess the ball
			possession = 0;
			print("Team 1 has Possession");
		}
		if(possessTeam == 1){//Team 2 Possess the ball
			possession = 1;
			print("Team 2 has Possession");
		}
	}

	public void QBSetBall(int hasBall){
		if(hasBall == 0){
			QBHasBall = 0;
		}
		if(hasBall == 1){
			QBHasBall = 1;
		}
	}

	public int getQBBall(){
		return QBHasBall;
	}

	public void setStartPos(Vector3 Pos){
		StartPos = Pos;
	}

	public Vector3 getStartPos(){
		return StartPos;
	} 

	public void setEndPos(Vector3 Pos){
		EndPos = Pos;
	}
	
	public Vector3 getEndPos(){
		return EndPos;
	} 

	public void setFirstDownPos(Vector3 Pos){
		FirstDownPos = Pos;
	}

	public Vector3 getFirstDownPos(){
		return FirstDownPos;
	}

	public void setDefensivePersuit(Transform thisTransform){
		DefensivePersuit = thisTransform;
	}

	public Transform getDefensivePersuit(){
		return DefensivePersuit;
	}

	public void setStateInt(int state){
		stateInt = state;
	}


	public int getStateInt(){
		return stateInt;
	}



}
