using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapPlayer : MonoBehaviour {

	private int m_lineIndex = 0;
	public int lineIndex {
		get { return m_lineIndex; }
	}

	private MusicSequencer mySequencer;

	public void Initialize (MusicSequencer sequencer) {
		mySequencer = sequencer;
		m_lineIndex = 0;
	}

	/// <summary>
	/// Stop all clips and queue them to be played at the right times.
	/// </summary>
	public void QueueClips () {
		PlayNextLine ();
		StartCoroutine (DelayThenPlay ());
	}

	private IEnumerator DelayThenPlay () {
		yield return new WaitForSeconds (mySequencer.songDuration * 0.5f);
		PlayNextLine ();
	}

	private void PlayNextLine () {
		mySequencer.audioSource.PlayOneShot (GameUtility.rapLyrics.rhymeLines [m_lineIndex].audio);
		m_lineIndex = (m_lineIndex + 1) % GameUtility.rapLyrics.rhymeLines.Length;
	}

	/// <summary>
	/// Stop all clips.
	/// </summary>
	public void Stop () {
		StopAllCoroutines ();
		m_lineIndex = 0;
	}
}
