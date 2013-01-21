public class Bullet : MonoBehaviour
{

    private double dx;
    private double dy;

    private Vector3 moveVector;

	public Bullet(double x, double y, double dx, double dy, dz)
	{
        //

    if (Input.GetButtonDown("Fire1")) {

    // Instantiate the projectile at the position and rotation of this transform
    var clone : Transform;
    clone = Instantiate(projectile, transform.position, transform.rotation);

    // Add force to the cloned object in the object's forward direction
    clone.rigidbody.AddForce(clone.transform.forward * shootForce);

        moveVector = new Vector3(dx, dy, dz); 
	}

    void Start()
    {
    }

    void Update()
    {
        bullet.transform.position += moveVector * Time.deltaTime;
    }

    void OnCollisionEnter(Collider c)
    {
        if (c.gameObject.name == "wall")
        {
            Debug.Log("kill bullet");
        }
    }
}
