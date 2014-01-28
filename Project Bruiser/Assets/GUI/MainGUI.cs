using UnityEngine;
using System.Collections;

public class MainGUI : MonoBehaviour {
	public Texture2D topBarTexture;
	public GUISkin thisMetalGUISkin;
	private GameObject theScoreObject;
	private Brain brainScript;
	private int score1;
	private int score0;
	public string down = "1st and 10";
	public string time = "2:10";
	private int isEscape;
	//int timer = 210;
	void Start(){
		score0 = 0;
		score1 = 0;
		isEscape = 0;
		theScoreObject = GameObject.Find("Brain") as GameObject;
		brainScript = theScoreObject.GetComponent("Brain") as Brain;
		Screen.lockCursor = true;
		Screen.showCursor = false;
		//GUI.skin = thisMetalGUISkin;
	}
	
	void Update() {
		score0 = brainScript.score0;
		score1 =brainScript.score1;
		if(Input.GetKeyDown(KeyCode.Escape)){
			Screen.lockCursor = false;
			Screen.showCursor = true;
			isEscape = 1;
			
		}else if(Input.GetKeyDown(KeyCode.Escape)&&(isEscape == 1)){
			Screen.lockCursor = true;
			Screen.showCursor = false;
			isEscape =0;
		}
	}
	
	void OnGUI () {
		GUI.skin = thisMetalGUISkin;
		if (GUI.Button (new Rect (10,650,150,100), "Restart")) {
			brainScript.setHiked(0);
			Application.LoadLevel("Bruiser1");
		}
		if (GUI.Button (new Rect (300,650,150,100), "Main Menu")) {
			Screen.lockCursor = false;
			Screen.showCursor = true;
			brainScript.setHiked(0);
			Application.LoadLevel("MainMenuScene");
			
		}
		GUI.DrawTexture(new Rect(0, 0, Screen.width, topBarTexture.height*3), topBarTexture);
		GUI.Label(new Rect(Screen.width/20,10,250,100), "Score1: " + score0,GUI.skin.GetStyle("label"));
		GUI.Label(new Rect((Screen.width/10)*8,10,250,100), "Score2: " + score1,GUI.skin.GetStyle("label"));
		GUI.Label(new Rect((Screen.width/10)*3,10,350,100), "Down: " + down,GUI.skin.GetStyle("label"));
		GUI.Label(new Rect((Screen.width/10)*6,10,250,100), "Time: " + time,GUI.skin.GetStyle("label"));
		//GUI.DrawTexture(new Rect(Screen.height/80, Screen.width/100, topBarTexture.width, topBarTexture.height), topBarTexture);
	}
	
	
	
	
	/*private Brain theBrain;
	public GUISkin thisMetalGUISkin;
	public Texture2D crosshairImage;
	// Use this for initialization
	void Start () {
		theBrain = GameObject.Find("Brain").GetComponent("Brain") as Brain;
		print(theBrain);
	//	gameObject.GetComponent(MouseLook).enabled = false;
	}
	
	
	void OnGui(){
		if (GUI.Button (new Rect (Screen.width/2,Screen.height/2,150,100), "I am a button")) {
			print ("You clicked the button!");
		}
		GUI.Label(new Rect(Screen.width/2,Screen.height/2,150,100),"YO");
		float intDivider = Screen.height/100;
		Rect titleRect = new Rect((Screen.width/5)/2,(3*intDivider),(4*(Screen.width/5)),(18*intDivider));
		GUI.skin = thisMetalGUISkin;
		GUI.Label(titleRect, ("Mathius: Defender of Earth!"),GUI.skin.GetStyle("label"));
    	float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
    	float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
    	GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);

	}*/
}
