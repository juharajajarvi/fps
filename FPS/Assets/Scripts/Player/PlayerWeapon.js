#pragma strict

class PlayerWeapon extends MonoBehaviour {

	public var bulletPrefab : Rigidbody;
	public var muzzleFlash : ParticleEmitter;
	
	public var gunShot : AudioClip;
	public var gunShotNoBullets : AudioClip;
	public var reload : AudioClip;
	
	public var bulletHole : Rigidbody;
	public var bulletHoleGravel : Rigidbody;
	
	private var minWaitTime : float;
	private var reloadTime : float;
	private var currentIdleTime : float;
	
	private var muzzleFlashLeft : int;
	private var range : float;
	private var damage : float;
	
	private var bullets : int;
	private var bulletsPerClip : int;
	private var clips : int;
	
	private var isReloading : boolean;
	
	function Start() {
		
		minWaitTime = 0.1f;
		reloadTime = 1.5f;
		
		currentIdleTime = minWaitTime + 1f;
		muzzleFlashLeft = 0;
		range = 300;
		damage = 40;
		
		bulletsPerClip = 30;
		bullets = bulletsPerClip;
		clips = 2;
		
		isReloading = false;
		
	}
	
	function OnGUI() {
		GUI.Label (Rect (100,10,1000,90), "RIFLE " + clips + " | " + bullets );
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
	
			if (!audio.isPlaying) {
				audio.PlayOneShot (gunShot);
			}
		}
	}
	
	function isGunReady() {
	
		// TODO rename for god's sake
		var isOkToShoot = ( currentIdleTime > minWaitTime );
		
		return ( ! isReloading && isOkToShoot );
		
	}
	
	function Shoot() {
		
		// TODO refactor
		if ( ! isGunReady() ) {
			return;
		}
		else if ( bullets == 0 ) {
			
			// Firing without bullets
			
			if ( clips > 0 ) {
				Reload();
			} else if ( ( currentIdleTime > minWaitTime )
				&& ! audio.isPlaying 
			) {
				currentIdleTime = 0f;
				audio.PlayOneShot (gunShotNoBullets );
			}
			return;
		}
		
		muzzleFlashLeft = 1;
		currentIdleTime = 0f;
		
		// Get the bullet exit position and direction
		var exitTransform = GameObject.Find("Player Bullet Exit").transform;
		var exitPosition = exitTransform.position;
		var exitDirection = exitTransform.TransformDirection ( Vector3.forward );
		
		var hit : RaycastHit;
		
		// Check collisions
		if ( Physics.Raycast ( exitPosition, exitDirection, hit, range ) ) {
		
			hit.collider.SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver );
			
			// Don't create bullet holes on aliens
			if ( hit.collider.name.IndexOf("Alien") == -1 ) {
	
				// TODO add a rolling system with maximum number of bullet holes
				var hitRotation = Quaternion.FromToRotation( Vector3.up, hit.normal );
				var hitPosition = hit.point + hit.normal * 0.01; // To avoid z-fighting
				
				var newBulletHole;
				
				if (hit.collider.gameObject.name == "Wall" || hit.collider.gameObject.name == "Floor") {
				
					if ( hit.collider.name == "Terrain" || hit.collider.name == "Bullet Hole Gravel(Clone)" ) {
						// Bullet hole for gravel
						newBulletHole = Instantiate(bulletHoleGravel, hitPosition, hitRotation);
					} else {
						// Default bullet hole
						newBulletHole = Instantiate(bulletHole, hitPosition, hitRotation);
					}
				
				}
			}
			
		}
		
		if ( bulletPrefab != null ) {
			
			// Instantiate the projectile at the position and rotation of this transform
			var newBullet = Instantiate(bulletPrefab, exitPosition, exitTransform.rotation);
			
		    // Add force to the cloned object in the object's forward direction
			newBullet.velocity = exitTransform.TransformDirection(Vector3.forward * 150);
			
		}
		
		bullets--;
		
		if ( bullets == 0 ) {
			Reload();
		}
	}
	
	function Reload() {
	
		if ( clips > 0 ) {
			isReloading = true;
	
			yield WaitForSeconds( reloadTime*(1f/3) );
							
			audio.PlayOneShot( reload );
	
			yield WaitForSeconds( reloadTime*(2f/3) );		
	
			clips--;
			bullets = bulletsPerClip;
			
			isReloading = false;
		}
		
	}
	
	function AddMagazine() {
		clips++;
		
		if ( bullets == 0 ) {
			Reload();
		}
	}
}