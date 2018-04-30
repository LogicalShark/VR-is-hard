using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//time
	public Text timeText;
	//points
	public Text countText;
	private int count;
	//health
	public Text healthText;
	public int maxHealth;
	private int health;
	//speeds
	public float speed;
	public float baseSpeed;
	public float maxSpeed;
	public float rampY;
	public float rampZ;
	public float jumpY;
	//abilities
	public float fireRate = 1.0F;
    private float nextFire = 0.0F;
	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;


	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set count
		count = 0;

		// Set health
		health = maxHealth;

		GameObject data = GameObject.Find("GameData");
		if(data!=null)
		{
			GameDataScript scr = (GameDataScript) data.GetComponent("GameDataScript");
			health = scr.hoverboardhealth;
			maxHealth = scr.hoverboardhealth;
			speed = scr.hoverboardacc;
			baseSpeed = scr.hoverboardspeed;
		}
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

		if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
		{
            nextFire = Time.time + fireRate;
			rb.AddForce(new Vector3(0,jumpY,0));
		}
		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above,
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		if((rb.velocity.magnitude)<=maxSpeed)
		{
			rb.AddForce(new Vector3(0,0,baseSpeed));
			rb.AddForce (movement * speed);
		}
		SetTimeText();
	}

	// When this game object intersects a collider with 'is trigger' checked,
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other)
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		//If the player hits an item
		if (other.gameObject.CompareTag ("coin"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear

			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			SetCountText ();
		}

		if (other.gameObject.CompareTag ("battery"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear

			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			rb.AddForce(new Vector3(0,0,10*baseSpeed));
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
				if(health < 0)
				{
			        SceneManager.LoadScene("MainMenu");
				}
			}
			rb.AddForce(new Vector3(0,0,-20*baseSpeed));

			rotatorScript.triggeredOn = true;

			SetCountText ();
		}

		//If the player hits a block
		if (other.gameObject.CompareTag ("ramp"))
		{
			// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rb.AddForce(new Vector3(0,rampY,rampZ));
			rb.AddForce (movement * speed);
		}

	}

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Coins: " + count.ToString() + "000";
		char barc = '\u2588';
		string bar = barc.ToString();
		string healthString = "";
		int h = maxHealth - health;
		for(int x = 0; x < h; x++)
		{
			healthString += " \n";
		}
		for(int x = 0; x < health; x++)
		{
			healthString += bar+"\n";
		}
		if(health == 1)
			healthText.color = Color.red;
		else if(health <= 3)
			healthText.color = Color.yellow;
		else
			healthText.color = Color.green;
		healthText.text = healthString;
		// Check if our 'count' is equal to or exceeded 12
		if (count >= 12)
		{

		}
	}
	void SetTimeText()
	{ 
		timeText.text = "Time: "+Mathf.RoundToInt(Time.time);
	}
}