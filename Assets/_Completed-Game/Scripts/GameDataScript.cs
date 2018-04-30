using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataScript : MonoBehaviour {
	public int hoverboardhealth = 5;
	public int hoverboardspeed = 8;
	public int hoverboardacc = 6;
	public int level = 1;
	public int deaths = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
}
