using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
	
	public Rigidbody bulletPrefab;
	private float minWaitTime;
	private float currentIdleTime;
	public ParticleEmitter muzzleFlash;
	private int muzzleFlashLeft; // TODO make private
	
	// Use this for initialization
	void Start () 
	{
		//muzzleFlash = GetComponentInChildren(ParticleEmitter);
		minWaitTime = 0.1f; // 0.3 seconds
		currentIdleTime = minWaitTime + 1f;
		muzzleFlashLeft = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentIdleTime += Time.deltaTime;
		if ( currentIdleTime > minWaitTime )
		{
			// prevent overflow
			currentIdleTime = minWaitTime + 1f;
		}
	}
	
	void LateUpdate() { 
		if ( muzzleFlashLeft > 0) {
			muzzleFlash.emit = true;
			muzzleFlashLeft--;
			/*if (audio) {
				if (!audio.isPlaying) {
					audio.Play ();
					audio.loop = true;
				}
			}*/
		}
		else {
			muzzleFlash.emit = false;
		}
	}
	
	public void Shoot(Transform transform)
	{
		if ( ! isGunReady() ) 
		{
			return;
		}
		
		muzzleFlashLeft = 1;
		currentIdleTime = 0f;
		
	    // Instantiate the projectile at the position and rotation of this transform
        Rigidbody newBullet;
        //newBullet = (Rigidbody) Instantiate(bulletPrefab, transform.position, transform.rotation);
		newBullet = (Rigidbody) Instantiate(bulletPrefab, transform.position + Vector3.forward*2, transform.rotation);
		
        // Add force to the cloned object in the object's forward direction
		newBullet.velocity = transform.TransformDirection (Vector3.forward * 150);
	}
	
	bool isGunReady() {
		return currentIdleTime > minWaitTime;
	}
}
