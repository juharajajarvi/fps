#pragma strict

class PlayerHealth extends DamageReceiver {

	function OnGUI() {
		GUI.Label (Rect (10,10,1000,90), "HEALTH " + hitPoints );
	}
	
	function Start () {
		hitPoints = 50f;
	}
	
	function Update () {
	
	}
	
	function AddHealth( amount : float ) {
		hitPoints += amount;
		if ( hitPoints > 100.0) {
			hitPoints = 100.0;
		}
	}
	
}