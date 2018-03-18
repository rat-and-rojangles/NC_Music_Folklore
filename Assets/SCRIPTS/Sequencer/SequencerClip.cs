using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A clip to go in the sequencer.
/// </summary>
public class SequencerClip : ScriptableObject {

	[SerializeField]
	private Sprite m_sprite;
	/// <summary>
	/// image for the playlist
	/// </summary>
	public Sprite sprite {
		get {
			return m_sprite;
		}
	}

	[SerializeField]
	private int m_length;
	/// <summary>
	/// Length of the clip in beats.
	/// </summary>
	public int length {
		get {
			return m_length;
		}
	}

	[SerializeField]
	private AudioClip m_audioClip;
	public AudioClip audioClip {
		get {
			return m_audioClip;
		}
	}
}
