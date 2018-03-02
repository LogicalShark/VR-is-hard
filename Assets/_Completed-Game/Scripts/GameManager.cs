using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {

	public GameObject house;
	public GameObject ground;
	public GameObject cat;
	public GameObject roadblock;
	public GameObject guard;
	public GameObject screw;
	public GameObject battery;
	public GameObject gear;
	public GameObject lwall;
	public GameObject rwall;
	public int width;
	//public int specificY;
	public int gameLength;
	public int sectionLength;
	public int houseLength;
	public int floorLength;
	private GameObject[] randBlock = new GameObject[3];
	private GameObject[] randItem = new GameObject[2];

	private void Start () {
		randBlock [0] = cat;
		randBlock [1] = guard;
		randBlock [2] = gear;
		randItem [0] = screw;
		randItem [1] = battery;
		//randItem [2] = roadblock;
		BeginGame();
	}

	private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	} 

	private void BeginGame () {

		//Creating the houses
		for (int z = -10; z < gameLength; z+=houseLength) 
		{
			float nextHousePosZ = Random.Range (-.5f, .5f);
			float nextHousePosX = Random.Range (-.5f, .5f);
			GameObject houseRight = Instantiate(house);
			houseRight.transform.position = new Vector3(width+nextHousePosX, -.5f, z+nextHousePosZ);

			float nextHousePosZ2 = Random.Range (-.5f, .5f);
			float nextHousePosX2 = Random.Range (-.5f, .5f);
			GameObject houseLeft = Instantiate(house);
			houseLeft.transform.position = new Vector3(-width+nextHousePosX2, -.5f, z+nextHousePosZ2);
		}

		//Creating the floor/walls
		for (int z = -10; z < gameLength-floorLength; z += floorLength) 
		{
			GameObject floor = Instantiate(ground);
			GameObject lw = Instantiate (lwall);
			GameObject rw = Instantiate (rwall);
			floor.transform.position = new Vector3(0, 0, z);
			lw.transform.position = new Vector3 (-1.3f, 0, z+50);
			rw.transform.position = new Vector3 (1.3f, 0, z+50);
		}

		//Creating the roadblocks
		for (int z = -10; z < gameLength-sectionLength; z += sectionLength) {

			int nextBlockPosZ = Random.Range (0, sectionLength-1);
			int nextBlockPosX = Random.Range (-width+1, width-1);
			int nextBlock = Random.Range(0, randBlock.Length);
			GameObject newBlock = Instantiate(randBlock [nextBlock]);
			newBlock.transform.position = new Vector3(nextBlockPosX, 2, z+nextBlockPosZ);
		}

		//Creating the items
		for (int z = -10; z < gameLength-sectionLength; z += sectionLength) {
			Random rnd = new Random();
			int nextItemPosZ = Random.Range (0, sectionLength-1);
			int nextItemPosX = Random.Range (-width+1, width-1);
			int nextItem = Random.Range(0, randItem.Length);
			GameObject newItem = Instantiate(randItem [nextItem]);
			newItem.transform.position = new Vector3(nextItemPosX, 2, z+nextItemPosZ);
		}

			

	}



	private void RestartGame () {}
}