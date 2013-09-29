#pragma strict
var idleAnimation : String;
function Start () {
idleAnimation = "Howl";
animation[idleAnimation].wrapMode =WrapMode.Loop;
//animation.CrossFade(idleAnimation,0.2);
}

function Update () {

}