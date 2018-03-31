using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSound : MonoBehaviour {

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip cheerSound;
	[SerializeField]
	private AudioClip booSound;

	public void PlayCheer () {
		PlayAudio (cheerSound);
	}

	public void PlayBoo () {
		PlayAudio (booSound);
	}

	public void PlayAudio (AudioClip clip) {
		audioSource.Stop ();
		audioSource.PlayOneShot (clip);
	}
}
