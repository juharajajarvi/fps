using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
	
	public Rigidbody bulletPrefab;
	private float minWaitTime;
	private float currentIdleTime;
	
	// Use this for initialization
	void Start () 
	{
		minWaitTime = 0.1f; // 0.3 seconds
		currentIdleTime = minWaitTime + 1f;
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
	
	public void Shoot(Transform transform) 
	{
		if ( ! isGunReady() ) 
		{
			return;
		}
		
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
