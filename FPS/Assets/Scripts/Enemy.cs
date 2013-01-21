using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    // x, y, speed, health

    private double health;
    
    /**
     * How much 
     */
    private double hitAmount;

    void Start()
    {
        health = 100;
        hitAmount = 40d;
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
        if (c.gameObject.name == "bullet(Clone)" || true)
        {
			GameObject.DestroyObject(c.gameObject);
			TakeHit();
        }
    }
}
