using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;

	//for the points
	public Text countText;
	private int count;

	//health count
	public Text healthText;
	private int health;

	//speeds
	public float baseSpeed;
	public float maxSpeed;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;


	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		// Set health to 2
		health = 2;

		// Run the SetCountText function to update the UI (see below)
		SetCountText ();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
	}

	// Each physics step..
	void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		if((rb.velocity.magnitude)<=maxSpeed)
		{
			rb.AddForce(new Vector3(0,0,baseSpeed));
			rb.AddForce (movement * speed);
		}
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		//If the player hits an item
		if (other.gameObject.CompareTag ("battery") || other.gameObject.CompareTag ("battery"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear

			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}


		//If the player hits a block
		if (other.gameObject.CompareTag ("gear") || other.gameObject.CompareTag ("cat") || other.gameObject.CompareTag ("screw") || other.gameObject.CompareTag ("guard"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear

			//other.gameObject.SetActive (false);

			Rotator rotatorScript = other.GetComponent<Rotator> ();
			bool rotatorTrig = rotatorScript.triggeredOn;
			if (!rotatorTrig) {
				health = health - 1;
			}

			rotatorScript.triggeredOn = true;



			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}

	}

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Count: " + count.ToString ();
		healthText.text = "Heath: " + health.ToString ();

		// Check if our 'count' is equal to or exceeded 12
		if (count >= 12) 
		{

		}
	}
}