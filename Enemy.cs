public class Enemy
{
    // x, y, speed, health

    private double health;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collider c)
    {
        if (c.gameObject.name == "bullet")
        {
            Debug.Log("kill bullet");
        }
    }
}
