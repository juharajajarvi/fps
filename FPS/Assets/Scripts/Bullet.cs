using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	
	public Rigidbody bulletHole;
	
    void Start()
    {
        // This needs to be added to the mouse reader

    }

    void Update()
    {
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "Wall")
        {
            Debug.Log("kill bullet");
			DestroyBullet();
			InstantiateBulletHole();
        } else if (c.gameObject.name == "Alien" ) {
			Debug.Log("hit enemy");
		}
    }
	
	void DestroyBullet() 
	{
		GameObject.DestroyObject(this.gameObject);
	}
	
	void InstantiateBulletHole()
	{
			Debug.Log ("instantiate bullet hole");
		    Rigidbody newBulletHole;
			Quaternion what;
		
			what = transform.rotation;
			what = Quaternion.Euler(90, what.y, what.z);
		
            newBulletHole = (Rigidbody) Instantiate(bulletHole, transform.position - Vector3.forward * 6f, what);

			//newBullet.velocity = transform.TransformDirection (Vector3.forward * 150);
	}
}
