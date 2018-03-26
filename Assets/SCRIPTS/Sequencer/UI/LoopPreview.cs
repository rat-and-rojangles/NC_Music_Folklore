using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopPreview : MonoBehaviour {
	[SerializeField]
	private AudioSource previewAudio;

	[SerializeField]
	private MusicSequencer sequencer;

	public void PreviewClip (SequencerClipLibraryButton clipButton) {
		StopPreview ();
		previewAudio.clip = clipButton.sequencerClip.audioClip;
		previewAudio.Play ();
	}

	public void StopPreview () {
		previewAudio.Stop ();
	}


}
