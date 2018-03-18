using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopLibrary : MonoBehaviour {

	[SerializeField]
	private MusicSequencer musicSequencer;

	[SerializeField]
	private GameObject prototype;

	void Start () {
		SequencerClip [] clips = GameUtility.allSequencerClips;
		prototype.GetComponent<SequencerClipLibraryButton> ().Initialize (clips [0]);
		musicSequencer.currentClipSelected = clips [0];
		for (int x = 1; x < clips.Length; x++) {
			Instantiate (prototype, transform, true).GetComponent<SequencerClipLibraryButton> ().Initialize (clips [x]);
		}
	}
}
