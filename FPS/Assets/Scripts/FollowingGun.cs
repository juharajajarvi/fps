using UnityEngine;
using System.Collections;

public class FollowingGun : MonoBehaviour {
	
	public Rigidbody gun;
	private Vector3 offset;
	
	void Start () {
		// This is the initial offset
		offset = this.transform.position - gun.transform.position;
	}
	
	void Update () {
		
		// Maintain the same offset as before
		gun.transform.position = this.transform.position + offset;
		
		gun.transform.rotation = this.transform.rotation;
		gun.transform.Rotate( Vector3.right * 180 );
		gun.transform.Rotate( Vector3.back * 180 );
	}
}
