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
        hitAmount = 30d;
    }

    void Update()
    {
        // Algorithm to move towards player
    }

    void TakeHit() 
    {
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
        Debug.Log("enemy died");
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "bullet")
        {
            TakeHit();
        }
    }
}
