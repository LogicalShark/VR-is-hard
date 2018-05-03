using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour {
	public GameObject player;
	public GameObject house1;
	public GameObject house2;
	public GameObject house3;
	public GameObject ground;
	public GameObject cat;
	public GameObject roadblock;
	public GameObject guard;
	public GameObject screw;
	public GameObject battery;
	public GameObject coin;
	public GameObject toolbox;
	public GameObject gearitem;
	public GameObject gear;
	public GameObject starburst;
	public GameObject lwall;
	public GameObject rwall;
	public GameObject ramp;
	public int width;
	//public int specificY;
	public int gameLength;
	public int sectionLength;
	public int houseLength;
	public int floorLength;
	private GameObject[] blocks = new GameObject[4];
	private GameObject[] items = new GameObject[5];

	private void Start () {
		blocks [0] = cat;
		blocks [1] = guard;
		blocks [2] = gear;
		blocks [3] = screw;
		items [0] = battery;
		items [1] = ramp;
		items [2] = coin;
		items [3] = toolbox;
		items [4] = gearitem;
		BeginGame();
	}

	private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
		if (player.transform.position.z >= gameLength-sectionLength)
		{
	        SceneManager.LoadScene("Cutscene 1");
		}

	} 

	private void BeginGame () {

		//Creating the houses
		for (int z = -10; z < gameLength; z+=houseLength) 
		{
			GameObject houseRight = null;
			GameObject houseLeft = null;
			float nextHousePosZ = Random.Range (-.5f, .5f);
			float nextHousePosX = Random.Range (-.5f, .5f);
			float nextHousePosZ2 = Random.Range (-.5f, .5f);
			float nextHousePosX2 = Random.Range (-.5f, .5f);
			float nextHousePosZ3 = Random.Range (-.5f, .5f);
			float nextHousePosX3 = Random.Range (-.5f, .5f);
			if(((z+10)/houseLength)%3 == 0)
			{
				houseRight = Instantiate(house1);
				houseLeft = Instantiate(house1);
			}
			if(((z+10)/houseLength)%3 == 1)
			{
				houseRight = Instantiate(house2);
				houseLeft = Instantiate(house2);
			}
			if(((z+10)/houseLength)%3 == 2)
			{
				houseRight = Instantiate(house3);
				houseLeft = Instantiate(house3);
			}
			houseRight.transform.position = new Vector3(width+nextHousePosX, 1.1f, z+nextHousePosZ);
			houseLeft.transform.position = new Vector3(-width+nextHousePosX2, 1.1f, z+nextHousePosZ2);
		}

		//Creating the floor/walls
		for (int z = -10; z < gameLength+floorLength+floorLength; z += floorLength) 
		{
			GameObject floor = Instantiate(ground);
			GameObject lw = Instantiate (lwall);
			GameObject rw = Instantiate (rwall);
			floor.transform.position = new Vector3(0, 0, z);
			lw.transform.position = new Vector3 (-1.3f, 0, z+50);
			rw.transform.position = new Vector3 (1.3f, 0, z+50);
		}

		//Creating the roadblocks
		for (int z = 1; z < gameLength-sectionLength; z += sectionLength) {

			float nextBlockPosZ = Random.Range (0.0f, ((float)sectionLength)-1.0f);
			float nextBlockPosX = Random.Range (-width+2f, width-2f);
			int nextBlock = Random.Range(0, blocks.Length);
			GameObject newBlock = Instantiate(blocks [nextBlock]);
			newBlock.transform.position = new Vector3(nextBlockPosX, 2, z+nextBlockPosZ);
		}

		//Creating the items
		for (int z = -10; z < gameLength-sectionLength; z += sectionLength) {
			Random rnd = new Random();
			float nextItemPosZ = Random.Range (0f, sectionLength-1f);
			float nextItemPosX = Random.Range (-width+2f, width-2f);
			int nextItem = Random.Range(0, items.Length);
			//Ramps
		
			if (nextItem == 1)
			{
				GameObject newItem = Instantiate(items [nextItem]);
				newItem.transform.position = new Vector3(nextItemPosX, 2.0f, z+nextItemPosZ);
				// GameObject newCoin = Instantiate(items[2]);
				// newCoin.transform.position = new Vector3(nextItemPosX, 2.0f, z+nextItemPosZ+1f);
			}
			//Multiple coins
			else if (nextItem == 2)
			{
				for(int c = 0; c < Random.Range(3,6); c++)
				{
					GameObject newItem = Instantiate(items [nextItem]);
					newItem.transform.position = new Vector3(nextItemPosX, 2f, z+nextItemPosZ+c/2f);
				}
			}
			else
			{
				GameObject newItem = Instantiate(items [nextItem]);
				newItem.transform.position = new Vector3(nextItemPosX, .3f, z+nextItemPosZ);
				GameObject starburst_item = Instantiate(starburst);
				starburst_item.transform.position = new Vector3(nextItemPosX, .3f, z+nextItemPosZ+.1f);

			}
		}

	}



	private void RestartGame () {}
}