using UnityEngine;
using System.Collections;
public class Tricky : MonoBehaviour {
	public GameObject player;
	public static int triggerDist = 10;
	private float triggeredOn;
	void Start()
	{
		triggeredOn = 0f;
	}
	void Update () 
	{
        float dist = transform.position.z - player.transform.position.z;
		if(triggeredOn < 3f && (dist < triggerDist))
		{
			float distance = Random.Range(-3f,3f);
			transform.Translate (new Vector3 (distance+transform.position.x, 0, 0));
			triggeredOn += Mathf.Abs(distance);
		}
	}
}	