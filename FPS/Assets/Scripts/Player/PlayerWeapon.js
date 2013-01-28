#pragma strict

public var bulletPrefab : Rigidbody;
public var muzzleFlash : ParticleEmitter;

private var minWaitTime : float;
private var currentIdleTime : float;
private var muzzleFlashLeft : int;

function Start() {
	minWaitTime = 0.1f; // 0.3 seconds
	currentIdleTime = minWaitTime + 1f;
	muzzleFlashLeft = 0;
}

function Update() {	
	currentIdleTime += Time.deltaTime;		
	if ( currentIdleTime > minWaitTime ) {
		// Prevent overflow.
		currentIdleTime = minWaitTime + 1f;
	}
}

function LateUpdate() {

	// If no muzzle has not been assigned...
	if ( muzzleFlash == null ) {
		return;
	}

	if ( muzzleFlashLeft > 0 ) {
		muzzleFlash.emit = true;
		muzzleFlashLeft--;
		/*
		if (audio) {
			if (!audio.isPlaying) {
				audio.Play ();
				audio.loop = true;
			}
		}
		*/
	}
	else {
		muzzleFlash.emit = false;
	}
	
}

function isGunReady() {
	return (currentIdleTime > minWaitTime);
}

function Shoot() {
	
	if ( ! isGunReady() ) {
		return;
	}
	
	muzzleFlashLeft = 1;
	currentIdleTime = 0f;
	
	if ( bulletPrefab != null ) {
		
		var exitTransform = GameObject.Find("Player Bullet Exit").transform;
		var exitPosition = exitTransform.position;
		
		// Instantiate the projectile at the position and rotation of this transform    
		var newBullet = Instantiate(bulletPrefab, exitPosition, transform.rotation);
		
	    // Add force to the cloned object in the object's forward direction
		newBullet.velocity = exitTransform.TransformDirection(Vector3.forward * 100);
		
	}
	
}