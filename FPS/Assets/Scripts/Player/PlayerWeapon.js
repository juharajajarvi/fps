#pragma strict

public var bulletPrefab : Rigidbody;
public var muzzleFlash : ParticleEmitter;

private var minWaitTime : float;
private var currentIdleTime : float;
private var muzzleFlashLeft : int;
private var range;
private var damage;

function Start() {
	minWaitTime = 0.1f; // 0.3 seconds
	currentIdleTime = minWaitTime + 1f;
	muzzleFlashLeft = 0;
	range = 300; // 300 meters
	damage = 40; // 40 percent
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
		muzzleFlash.Emit();
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
	
	// Get the bullet exit position and direction
	var exitTransform = GameObject.Find("Player Bullet Exit").transform;
	var exitPosition = exitTransform.position;
	var exitDirection = exitTransform.TransformDirection ( Vector3.forward );
	
	var hit : RaycastHit;
	
	if ( Physics.Raycast ( exitPosition, exitDirection, hit, range ) ) {
		hit.collider.SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver );
	}
	
	// We could use this for visual bullets and raycast for collision detection
	if ( bulletPrefab != null ) {
		
		// Instantiate the projectile at the position and rotation of this transform
		var newBullet = Instantiate(bulletPrefab, exitPosition, exitTransform.rotation);
		
	    // Add force to the cloned object in the object's forward direction
		newBullet.velocity = exitTransform.TransformDirection(Vector3.forward * 150);
		
	}
	
}