using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour {

	public AudioClip SoundToPlay;
	public float Volume;
	AudioSource audio;
	public bool alreadyPlayed = false;
	void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter()
	{
		if (true)
		{
			audio.PlayOneShot(SoundToPlay, Volume);
			alreadyPlayed = true;
		}
	}
}
