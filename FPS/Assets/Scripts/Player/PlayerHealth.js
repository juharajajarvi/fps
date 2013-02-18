#pragma strict

class PlayerHealth extends DamageReceiver {

	private var isAlive : boolean;
	public var deathScreen : Texture;

	function OnGUI() {
		GUI.Label (Rect (10,10,1000,90), "HEALTH " + hitPoints );
		
		if ( ! isAlive ) {
			GUI.DrawTexture( new Rect(0, 0, 1024, 1024), deathScreen );
		}
	}
	
	function Start () {
		hitPoints = 50f;
		isAlive = true;
	}
	
	function Update () {
	
	}
	
	function AddHealth( amount : float ) {
		hitPoints += amount;
		if ( hitPoints > 100.0) {
			hitPoints = 100.0;
		}
	}
	
	function ReduceHealth( amount : float ) {
		hitPoints -= amount;
		if ( hitPoints < 0.0) {
			hitPoints = 0.0;
			// Player is dead :(
			if (isAlive) {
				Die();
			}
		}
	}
	
	function IsAlive() {
		return isAlive;
	}

	function Die() {
		isAlive = false;
		gameObject.rigidbody.useGravity = true;
	}	
}