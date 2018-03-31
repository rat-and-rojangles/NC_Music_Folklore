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

	public void PlayNextLine () {
		mySequencer.audioSource.PlayOneShot (GameUtility.rapLyrics.rhymeLines [m_lineIndex].audio);
		m_lineIndex = (m_lineIndex + 1) % GameUtility.rapLyrics.rhymeLines.Length;
	}

	/// <summary>
	/// Stop all clips.
	/// </summary>
	public void Stop () {
		m_lineIndex = 0;
	}
}
