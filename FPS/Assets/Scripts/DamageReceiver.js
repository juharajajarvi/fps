
#pragma strict

var hitPoints = 100.0;
var deadReplacement : Rigidbody;

function ApplyDamage( damage : float ) {
	
	if (hitPoints <= 0.0) {
		return;
	}
	
	hitPoints -= damage;
	
	if (hitPoints <= 0.0) {
		
		if (deadReplacement) {
			var dead : Rigidbody = Instantiate(deadReplacement, transform.position, transform.rotation);
			dead.rigidbody.velocity = rigidbody.velocity;
			dead.angularVelocity = rigidbody.angularVelocity;
		}
		
		Destroy(gameObject);
		
	}
	
}

@script RequireComponent (Rigidbody)