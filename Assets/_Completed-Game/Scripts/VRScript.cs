// using System.Collections;
// using System.Collections.Generic;
// using System.IO.Ports;
// using UnityEngine;

// public class VRScript : MonoBehaviour {
// 	SerialPort stream = new SerialPort("COM4", 9600); 

// 	// Use this for initialization
// 	void Start () {
// 		stream.Open();
// 		StartCoroutine(Example());
// 	}
	
// 	// Update is called once per frame
// 	IEnumerator Example () {
// 		Debug.Log(stream.ReadLine());
// 		yield return new WaitForSeconds(1);
// 	}
// }