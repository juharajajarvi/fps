#pragma strict

public var amount : float = 20f;

function OnTriggerEnter(other: Collider){
	if (other.name == "Player") {
		other.SendMessageUpwards("AddHealth", amount);
		GameObject.Destroy(gameObject.transform.parent.gameObject);
	}
}

@script RequireComponent (Rigidbody)