using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotator : MonoBehaviour {
	public GameObject player;
	public float rotationAmountz = 45;
	public float rotationAmounty = 0;
	public float rotationAmountx = 0;
	public static int triggerDist = 20;
	void Update()
	{
        float dist = transform.position.z - player.transform.position.z;
		if(dist < (triggerDist - 1))
		{
			transform.Rotate (new Vector3 (rotationAmountx, rotationAmounty, rotationAmountz) * Time.deltaTime);
		}
	}
}
