using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {

	public GameObject house;
	public GameObject cat;
	public GameObject block;
	public GameObject guard;
	public GameObject ground;
	public int width;
	public int gameLength;
	public int sectionLength;
	public int houseLength;
	private GameObject[] randBlock = new GameObject[3];

	private void Start () {
		GameObject cat1 = cat;
		GameObject block1 = block;
		GameObject guard1 = guard;
		randBlock [0] = cat1;
		randBlock [1] = block1;
		randBlock [2] = guard1;
		BeginGame();
	}

	private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	} 

	private void BeginGame () {
		for (int z = -10; z < gameLength; z+=houseLength) 
		{
			GameObject houseRight = Instantiate(house);
			houseRight.transform.position = new Vector3(width, -1, z);
			GameObject houseLeft = Instantiate(house);
			houseLeft.transform.position = new Vector3(-width, -1, z);
			GameObject floor = Instantiate(ground);
			floor.transform.position = new Vector3(0, 0, z);
		}

		for (int z = -10; z < gameLength-sectionLength; z += sectionLength) {
			Random rnd = new Random();
			int nextBlockPosZ = Random.Range (0, sectionLength-1);
			int nextBlockPosX = Random.Range (-width, width);
			int nextBlock = Random.Range(0, randBlock.Length);
			GameObject block = Instantiate(randBlock [nextBlock]);
			block.transform.position = new Vector3(nextBlockPosX, 3, z+nextBlockPosZ);
		}
	}

	private void RestartGame () {}
}