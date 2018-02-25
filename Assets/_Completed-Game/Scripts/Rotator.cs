﻿using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public GameObject player;
	public float rotateX;
	public float rotateZ;
	public float rotationSpeed;
	public float houseY;
	public float specificY;
	public int triggerDist;
	private double hasRotated;
	public bool triggeredOn;
	void Start()
	{
		triggeredOn = false;
		hasRotated = 0;
		transform.position = new Vector3(transform.position.x, specificY, transform.position.z);
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