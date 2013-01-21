using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    float speed = 3.0f, rot= 3.0f;
	// Use this for initialization
 
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //bla-bla
		
		// Juha's note:
		// I think it would be better to use WASD keys with strafe
		// (meaning that left and right buttons doesn't turn the player,
		// just translate).
		// And use the mouse for looking around
		
        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, Input.GetAxis("Horizontal") * rot, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        this.transform.Translate(forward * curSpeed * Time.deltaTime);
		
		
		// Left click or mouse is kept down
		if (Input.GetButton("Fire1")) {
			// Shoot with weapon
			GetComponent<Weapon>().Shoot(transform);
		}
		
		
	}
}
