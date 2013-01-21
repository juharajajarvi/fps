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

    void CheckIfDied() 
    {
        if ( health < 0 ) 
        {
            Die();
        }
    }
	
	void InstantiateBulletHole()
	{
			Debug.Log ("a bullet hit the wall");
		    Rigidbody newBulletHole;
			Quaternion what;
		
			what = transform.rotation;
		
            newBulletHole = (Rigidbody) Instantiate(bulletHole, transform.position - Vector3.forward * 1f, transform.rotation);
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "bullet(Clone)" )
        {
			GameObject.DestroyObject(c.gameObject);
			InstantiateBulletHole();
        }
    }
}
