using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public GameObject player;
	public float rotateX;
	public float rotateZ;
	public float rotationSpeed;
	public float houseY;
	public int triggerDist;
	private double hasRotated;
	void Start()
	{
		hasRotated = 0;
	}
	// Before rendering each frame..
	void Update () 
	{
        float dist = Vector3.Distance(player.transform.position, transform.position);
		if((hasRotated<=90) && (dist<triggerDist))
		{
			transform.Rotate (new Vector3 (rotateX/rotationSpeed, houseY, rotateZ/rotationSpeed));
			hasRotated += 90.0/rotationSpeed;
		}
	}
}	