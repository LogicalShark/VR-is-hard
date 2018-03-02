using UnityEngine;
using System.Collections;

public class Aura : MonoBehaviour {
	public GameObject player;
	public static int triggerDist = 100;
	public bool triggeredOn;

	void Start()
	{
		triggeredOn = false;
		this.GetComponent<Renderer> ().enabled = false;
	}

	void Update () 
	{
		float dist = transform.position.z - player.transform.position.z;
		if(dist<triggerDist)
		{
			this.GetComponent<Renderer> ().enabled = true;
		}
	}
}	