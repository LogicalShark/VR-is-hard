using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public GameObject player;
	public float rotateX;
	public float rotateY;
	public float rotateZ;
	public float rotationSpeed;
	public float offsetY;
	public static int triggerDist = 50;
	private double hasRotated;
	public bool triggeredOn;
	void Start()
	{
		triggeredOn = false;
		hasRotated = 0;
		transform.position = new Vector3(transform.position.x, offsetY, transform.position.z);
	}
	void Update () 
	{
        float dist = transform.position.z - player.transform.position.z;
		if((hasRotated<=90) && (dist<triggerDist))
		{
			transform.Rotate (new Vector3 (rotateX/rotationSpeed, rotateY/rotationSpeed, rotateZ/rotationSpeed));
			hasRotated += 90.0/rotationSpeed;
		}
	}
}	