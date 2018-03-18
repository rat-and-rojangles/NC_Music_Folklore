using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerTrack : MonoBehaviour {
	public SequencerClip [] clips;
	private MusicSequencer mySequencer;

	public void Initialize (MusicSequencer musicSequencer) {
		mySequencer = musicSequencer;
		clips = new SequencerClip [MusicSequencer.BEATS_PER_SONG];
	}

	public bool Insert (SequencerClip newClip, int beatIndex) {
		if (newClip == null) {
			return false;
		}
		else if (beatIndex >= clips.Length || beatIndex < 0) {
			return false;
		}
		else if (beatIndex + newClip.length > clips.Length) {
			return false;
		}
		else {
			int indexOfPreviousClip = beatIndex;
			SequencerClip previousClip = clips [indexOfPreviousClip];
			while (previousClip == null && indexOfPreviousClip > 0) {
				indexOfPreviousClip--;
				previousClip = clips [indexOfPreviousClip];
			}
			if (previousClip != null && indexOfPreviousClip + previousClip.length > beatIndex) {
				return false;
			}
			for (int x = beatIndex; x < beatIndex + newClip.length; x++) {
				if (clips [x] != null) {
					return false;
				}
			}

			clips [beatIndex] = newClip;
			return true;
		}
	}

	public bool RemoveAt (int beatIndex) {
		bool result = clips [beatIndex] != null;
		clips [beatIndex] = null;
		return result;
	}

	/// <summary>
	/// Stop all clips and queue them to be played at the right times.
	/// </summary>
	public void QueueClips () {
		for (int x = 0; x < clips.Length; x++) {
			if (clips [x] != null) {
				StartCoroutine (DelayThenPlay (mySequencer.beatDuration * x, clips [x].audioClip));
			}
		}
	}

	/// <summary>
	/// Stop all clips.
	/// </summary>
	public void StopAllClips () {
		StopAllCoroutines ();
	}

	private IEnumerator DelayThenPlay (float delay, AudioClip clip) {
		yield return new WaitForSeconds (delay);
		mySequencer.audioSource.PlayOneShot (clip);
	}
}
