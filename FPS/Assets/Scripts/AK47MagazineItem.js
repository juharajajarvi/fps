#pragma strict

function OnTriggerEnter(other: Collider){
	if (other.name == "Player") {
		other.SendMessageUpwards("AddMagazine");
		GameObject.Destroy(gameObject.transform.parent.gameObject);
	}
}

@script RequireComponent (Rigidbody)