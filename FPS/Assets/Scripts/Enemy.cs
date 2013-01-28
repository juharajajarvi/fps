using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public double health = 100;    
    public double hitAmount = 40d;

    void Start()
    {
    }

    void Update()
    {
        // Algorithm to move towards player
    }

    void TakeHit() 
    {
		Debug.Log ("Enemy hit!");
        health -= hitAmount;
        CheckIfDied();
    }

    void CheckIfDied() 
    {
        if ( health < 0 ) 
        {
            Die();
        }
    }

    void Die() 
    {
        Debug.Log("Enemy killed");
		GameObject.DestroyObject(this.gameObject);
    }

    void OnCollisionEnter(Collision c)
    {
        if ( c.gameObject.name == "Bullet(Clone)" )
        {
			GameObject.DestroyObject(c.gameObject);
			TakeHit();
        }
    }
	
}
