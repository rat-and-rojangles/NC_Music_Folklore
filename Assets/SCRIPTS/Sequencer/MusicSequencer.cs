using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Custom music
/// </summary>
public class MusicSequencer : MonoBehaviour {
	/// <summary>
	/// Begin playback. Will always start from the beginning.
	/// </summary>
	public void Play () {
		Stop ();
		StartCoroutine (Playback ());
		m_isPlaying = true;
	}
	/// <summary>
	/// Stop playback.
	/// </summary>
	public void Stop () {
		audioSource.Stop ();
		StopAllCoroutines ();
		foreach (SequencerTrack sqt in tracks) {
			sqt.StopAllClips ();
		}
		playbackStartTime = -1f;
		m_isPlaying = false;
	}

	/// <summary>
	/// Stop if playing, start if not.
	/// </summary>
	public void TogglePlayback () {
		if (isPlaying) {
			Stop ();
		}
		else {
			Play ();
		}
	}

	private bool m_isPlaying = false;
	public bool isPlaying {
		get {
			return m_isPlaying;
		}
	}

	public const int BARS_PER_SONG = 8;
	public static int BEATS_PER_SONG {
		get { return BARS_PER_SONG * 4; }
	}

	private AudioSource m_audioSource;
	public AudioSource audioSource {
		get {
			if (m_audioSource == null) {
				m_audioSource = GetComponent<AudioSource> ();
			}
			return m_audioSource;
		}
	}

	/// <summary>
	/// Tempo of the song in BPM. All loops should be at this tempo.
	/// </summary>
	[SerializeField]
	private float tempo = 128f;
	/// <summary>
	/// Duration of one beat, in seconds.
	/// </summary>
	public float beatDuration {
		get {
			return 60f / tempo;
		}
	}
	/// <summary>
	/// Duration of the song, in seconds.
	/// </summary>
	public float songDuration {
		get {
			return beatDuration * BEATS_PER_SONG;
		}
	}

	/// <summary>
	/// The thing you paint with. should never be null
	/// </summary>
	public SequencerClip currentClipSelected = null;
	public GameObject clipButtonPrefab;

	[SerializeField]
	private SequencerTrack [] tracks;

	void Start () {
		foreach (SequencerTrack sqt in tracks) {
			sqt.Initialize (this);
		}
	}

	/// <summary>
	/// The loop of the music playing.
	/// </summary>
	private IEnumerator Playback () {
		while (true) {
			foreach (SequencerTrack sqt in tracks) {
				sqt.QueueClips ();
			}
			playbackStartTime = Time.realtimeSinceStartup;
			yield return new WaitForSeconds (songDuration);
		}
	}

	private float playbackStartTime = -1f;
	/// <summary>
	/// How far through the song we are
	/// </summary>
	public float playbackRatio {
		get {
			if (playbackStartTime < 0f) {
				return -1;
			}
			else {
				return (Time.realtimeSinceStartup - playbackStartTime) / songDuration;
			}
		}
	}

}
