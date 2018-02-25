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
	public int width;
	public int gameLength;
	public int sectionLength;
	public int houseLength;
	public int floorLength;
	private GameObject[] randBlock = new GameObject[3];
	private GameObject[] randItem = new GameObject[3];

	private void Start () {
		randBlock [0] = cat;
		randBlock [1] = guard;
		randBlock [2] = gear;
		randItem [0] = screw;
		randItem [1] = battery;
		randItem [2] = roadblock;
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
			GameObject houseRight = Instantiate(house);
			houseRight.transform.position = new Vector3(width, -1, z);
			GameObject houseLeft = Instantiate(house);
			houseLeft.transform.position = new Vector3(-width, -1, z);
		}

		//Creating the floor
		for (int z = -10; z < gameLength-floorLength; z += floorLength) 
		{
			GameObject floor = Instantiate(ground);
			floor.transform.position = new Vector3(0, 0, z);
		}

		//Creating the roadblocks
		for (int z = -10; z < gameLength-sectionLength; z += sectionLength) {
			Random rnd = new Random();
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