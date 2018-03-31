using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhymeSceneControl : MonoBehaviour {

	[SerializeField]
	private RhymeLyrics rhymeLyrics;

	[SerializeField]
	private MusicSequencer sequencer;

	public void AttemptToToggle () {
		if (rhymeLyrics.IsValid ()) {
			rhymeLyrics.Save ();
			sequencer.Play ();
		}
	}

}
