#pragma strict

function OnTriggerEnter(other: Collider){
	Debug.Log("wtf kerää se");
}

function OnCollisionEnter(other: Collision){
	Debug.Log("wtf kerää se");
}

@script RequireComponent (Rigidbody)