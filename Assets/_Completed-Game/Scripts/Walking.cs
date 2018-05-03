using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {
	public float transAmountz = 0;
	public float transAmounty = 0;
	public float transAmountx = 2;
	private int direction = 0;
	private int direction2 = 0;
	private SpriteRenderer sr; 
	public float width;
	void Start()
	{
		sr = gameObject.GetComponent<SpriteRenderer>();
		direction = Random.Range(0,2);
	}
	void Update()
	{
		if(transform.position.x >= width)
		{
			direction = 0;
			direction2 += 1;
			sr.flipX = !sr.flipX;
		}
		if(transform.position.x <= -width)
		{
			direction = 1;
			direction2 += 1;
			sr.flipX = !sr.flipX;

		}			
		if(direction == 1)
		{
			if (direction2 % 4 == 0 || direction2 % 4 == 1) {
				transform.Translate (new Vector3 (transAmountx, transAmounty, -Random.Range (-2f, 2f) * transAmountz) * Time.deltaTime);
				//sr.flipX = !sr.flipX;
			}
			else
				transform.Translate(new Vector3 (transAmountx, -transAmounty, -Random.Range(-2f, 2f)*transAmountz) * Time.deltaTime);			
		}
		else
		{
			if(direction2%4==0 || direction2%4==1)
				transform.Translate(new Vector3 (-transAmountx, -transAmounty, -Random.Range(-2f, 2f)*transAmountz) * Time.deltaTime);
			else
				transform.Translate(new Vector3 (-transAmountx, transAmounty, -Random.Range(-2f, 2f)*transAmountz) * Time.deltaTime);			
		}

	}
}
