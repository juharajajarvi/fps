using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
	
	public Rigidbody bulletHole;
	
    void Start()
    {
    }

    void Update()
    {
    }

	void InstantiateBulletHole(Vector3 bulletPosition)
	{
			// Position depends mainly on the bullet.
		 	// TODO but make sure the hole won't be inside the wall
			Vector3 holePosition;
			holePosition = bulletPosition - 3 * Vector3.forward;
		
			// Rotation depends on the the wall. This doesn't with roof....
			Quaternion holeRotation;
			holeRotation = Quaternion.Euler(90, this.gameObject.transform.eulerAngles.y, this.gameObject.transform.eulerAngles.z);

			Rigidbody newBulletHole;
			newBulletHole = (Rigidbody) Instantiate(bulletHole, holePosition, holeRotation);
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "bullet(Clone)" )
        {
			//Debug.Log ("a bullet hit the wall");
			InstantiateBulletHole(c.gameObject.transform.position);
			GameObject.DestroyObject(c.gameObject);
        }
    }
}
