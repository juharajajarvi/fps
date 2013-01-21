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
		    Rigidbody newBulletHole;
		
			Quaternion bulletRot;
        
			Debug.Log("hit wall");
			Debug.Log("y " + this.gameObject.transform.rotation.y* Mathf.Rad2Deg + " z " + this.gameObject.transform.rotation.z* Mathf.Rad2Deg);
		
			bulletRot = Quaternion.Euler(90, transform.rotation.y * Mathf.Rad2Deg, transform.rotation.z* Mathf.Rad2Deg);
			newBulletHole = (Rigidbody) Instantiate(bulletHole, bulletPosition, bulletRot);
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "bullet(Clone)" )
        {
			//Debug.Log ("a bullet hit the wall");
			GameObject.DestroyObject(c.gameObject);
			InstantiateBulletHole(c.gameObject.transform.position);
        }
    }
}
