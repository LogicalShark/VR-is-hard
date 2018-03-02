using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotator : MonoBehaviour {
	public float rotationAmountz = 45;
	public float rotationAmounty = 0;
	public float rotationAmountx = 0;
	void Update() 
	{
		transform.Rotate (new Vector3 (rotationAmountx, rotationAmounty, rotationAmountz) * Time.deltaTime);
	}
}
