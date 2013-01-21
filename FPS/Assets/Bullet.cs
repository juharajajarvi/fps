using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        // This needs to be added to the mouse reader

    }

    void Update()
    {
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "wall")
        {
            Debug.Log("kill bullet");
        }
    }
}
