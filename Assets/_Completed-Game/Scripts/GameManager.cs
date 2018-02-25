using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject house;
	public GameObject ground;
	public int width;

	private void Start () {
		BeginGame();
	}

	private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	} 

	private void BeginGame () {
		for (int z = -10; z < 1000; z+=2) 
		{
			GameObject cube = Instantiate(house);
			cube.transform.position = new Vector3(width, -1, z);
			GameObject cube2 = Instantiate(house);
			cube2.transform.position = new Vector3(-width, -1, z);
			GameObject floor = Instantiate(ground);
			floor.transform.position = new Vector3(0, 0, z);
		}
	}

	private void RestartGame () {}
}