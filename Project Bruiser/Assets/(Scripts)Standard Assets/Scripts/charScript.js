#pragma strict
var rotationSpeed : float = 10;
var walkSpeed :  float = 7;
var gravity : float = 50;
private var yRot : float = 0;
var body : Transform;
var idleAnimation : String;
var walkAnimation : String;
var throwAnimation : String;
var jumpAnimation : String;
var isQB : int;
var canJump : boolean;
//Sprint Varriables
var sprint : boolean;
var baseSprint : int;
var maxSprint : int  = 25;
var sprintTimer : int = 100;


function Start(){
	canJump = true;
	sprint = false;
	baseSprint = walkSpeed;
}

function Update () {
	var  Controller : CharacterController =  GetComponent(CharacterController);
	var vertical :  Vector3 = transform.TransformDirection(Vector3.forward);
	var horizontal :  Vector3 = transform.TransformDirection(Vector3.right);
	var height : Vector3 = transform.TransformDirection(Vector3.up);
	
	if((sprintTimer < 100) && (Input.GetKeyDown(KeyCode.LeftShift) == false)){
		walkSpeed = baseSprint;
		sprintTimer++;
		print(sprintTimer);
		sprint = false;
		
	}
	if(Input.GetKeyDown("space")&& canJump == true){
		animation.CrossFade(jumpAnimation,0.2);
		jump();
		canJump = false;
	}
	
	if(Input.GetKeyDown(KeyCode.LeftShift)){
		sprint = true;
		if((sprint == true)&&(sprintTimer >= 0)){
		walkSpeed = maxSprint;
		//sprint = false;
		sprintTimer--;
		print(sprintTimer);
		//sprint = false;
		}
	}
	
	
	if(Input.GetAxis("Vertical") || Input.GetAxis("Horizontal")){
		animation.CrossFade(walkAnimation,0.2);
		animation[walkAnimation].speed = walkSpeed/10;
		Controller.Move((vertical * (walkSpeed * Input.GetAxis("Vertical")))*Time.deltaTime);
		Controller.Move((horizontal * (walkSpeed * Input.GetAxis("Horizontal")))*Time.deltaTime);
	}
	else{
		animation.CrossFade(idleAnimation,0.2);
	}
	
	if(Input.GetAxis("Mouse X")){
		yRot += 10 * Input.GetAxis("Mouse X");
	}
	transform.rotation = Quaternion.Euler(0, yRot, 0);
	Controller.Move(height * gravity * Time.deltaTime);
	//if(isQB==1){
		if(Input.GetMouseButtonDown(0)){
			Debug.Log("button Down!");
			animation.CrossFade(throwAnimation,0.2);
		//}
	}
}

function LateUpdate(){
  // Rotate the Character to match the direction he/she is going
  if(Input.GetAxis("Vertical") == 0){
    if(Input.GetAxis("Horizontal") > 0){
      body.localEulerAngles.y = 180;
    }else if(Input.GetAxis("Horizontal") < 0){
      body.localEulerAngles.y = 0;
    }
  }else if(Input.GetAxis("Vertical") > 0){
    if(Input.GetAxis("Horizontal") > 0){
      body.localEulerAngles.y = 135;
    }else if(Input.GetAxis("Horizontal") < 0){
      body.localEulerAngles.y = 45;
    }
  }else if(Input.GetAxis("Vertical") < 0){
    if(Input.GetAxis("Horizontal") == 0){
      body.localEulerAngles.y = -90;
    }else if(Input.GetAxis("Horizontal") > 0){
      body.localEulerAngles.y = -135;
    }else if(Input.GetAxis("Horizontal") < 0){
      body.localEulerAngles.y = -45;
    }
  }
}

function jump(){
	gravity = 20;
	animation.CrossFade(jumpAnimation,0.2);
	yield WaitForSeconds(0.3);
	gravity = -20;
	yield WaitForSeconds(0.3);
	canJump = true;
	
}

/*function OnCollisionEnter(collision : Collision){
	if(collision.gameObject.name == "Terrain"){
		canJump = true;
	}
}*/