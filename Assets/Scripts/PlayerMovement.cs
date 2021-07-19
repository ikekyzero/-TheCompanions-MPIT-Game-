using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour {
	public float maxSpeed;
	public float acceleration;
	public float steering;
	public Animator animator;

	public Rigidbody2D rb;
	private float currentSpeed;

	private static PlayerMovement _instance;
	public static PlayerMovement Instance { get { return _instance; } }
	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}
	}

	private void Start()
	{
		this.rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		// Get input
		float v = Input.GetAxis("Horizontal");
		float h = Input.GetAxis("Vertical");

		// Calculate speed from input and acceleration (transform.up is forward)
		Vector2 speed = transform.right * (v * acceleration);
		rb.AddForce(speed);

		// Create car rotation
		/*float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
		if (direction >= 0.0f)
		{
			rb.rotation += h * steering * (rb.velocity.magnitude / maxSpeed);
		}
		else
		{
			rb.rotation -= h * steering * (rb.velocity.magnitude / maxSpeed);
		}*/

		// Change velocity based on rotation
		float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;
		Vector2 relativeForce = Vector2.right * driftForce;
		Debug.DrawLine(rb.position, rb.GetRelativePoint(relativeForce), Color.green);
		rb.AddForce(rb.GetRelativeVector(relativeForce));

		// Force max speed limit
		if (rb.velocity.magnitude > maxSpeed)
		{
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
		currentSpeed = rb.velocity.magnitude;
		//Debug.Log(rb.velocity.magnitude);
	}

}


