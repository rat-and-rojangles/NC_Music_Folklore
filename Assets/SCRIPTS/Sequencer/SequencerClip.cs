using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A clip to go in the sequencer.
/// </summary>
public class SequencerClip : ScriptableObject {

	[SerializeField]
	private Sprite m_playlistSprite;
	/// <summary>
	/// image for the playlist
	/// </summary>
	public Sprite playlistSprite {
		get {
			return m_playlistSprite;
		}
	}

	[SerializeField]
	private Sprite m_bannerSprite;
	/// <summary>
	/// image for the loop library. 624x200 
	/// </summary>
	public Sprite bannerSprite {
		get {
			return m_bannerSprite;
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
