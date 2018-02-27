using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {

	private AudioSource audioSource;

	void OnEnable () {
		// animate
	}

	public void Close () {
		// start coroutine AnimateClose
		// should fade out volume
		gameObject.SetActive (false);   // should be at the end of the coroutine
	}

	public void ShowData (CollectibleItemBookEntry bookEntry) {
		print (bookEntry.text);
	}

	public void PlayVoiceover (CollectibleItemBookEntry bookEntry) {
		audioSource.Stop ();
		audioSource.clip = bookEntry.voiceover;
		audioSource.Play ();
	}
}
