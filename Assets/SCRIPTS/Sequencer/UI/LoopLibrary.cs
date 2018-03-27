using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopLibrary : MonoBehaviour {

	[SerializeField]
	private MusicSequencer musicSequencer;

	[SerializeField]
	private GameObject prototype;

	private SequencerClipLibraryButton [] clipButtonList;

	void Start () {
		SequencerClip [] clips = GameUtility.allSequencerClips;

		clipButtonList = new SequencerClipLibraryButton [clips.Length];

		SequencerClipLibraryButton currentSCLB = prototype.GetComponent<SequencerClipLibraryButton> ();
		currentSCLB.Initialize (clips [0]);
		clipButtonList [0] = currentSCLB;

		for (int x = 1; x < clips.Length; x++) {
			currentSCLB = Instantiate (prototype, transform, true).GetComponent<SequencerClipLibraryButton> ();
			currentSCLB.Initialize (clips [x]);
			clipButtonList [x] = currentSCLB;
		}

		musicSequencer.currentClipSelected = clips [0];
	}

	public void UpdateHighlighted () {
		foreach (SequencerClipLibraryButton clipButton in clipButtonList) {
			clipButton.highlighted = clipButton.sequencerClip == musicSequencer.currentClipSelected;
		}
	}
}
