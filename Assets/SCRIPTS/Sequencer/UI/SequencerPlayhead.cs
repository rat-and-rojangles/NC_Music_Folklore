using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequencerPlayhead : MonoBehaviour {
	[SerializeField]
	private MusicSequencer musicSequencer;

	private RectTransform m_rectTransform;
	private RectTransform rectTransform {
		get {
			if (m_rectTransform == null) {
				m_rectTransform = GetComponent<RectTransform> ();
			}
			return m_rectTransform;
		}
	}

	private Image m_image;
	private Image image {
		get {
			if (m_image == null) {
				m_image = GetComponent<Image> ();
			}
			return m_image;
		}
	}

	private Vector2 basePosition;
	void Start () {
		basePosition = rectTransform.anchoredPosition;
	}

	void Update () {
		float playbackRatio = musicSequencer.playbackRatio;
		image.enabled = playbackRatio >= 0f;
		if (image.enabled) {
			rectTransform.anchoredPosition = basePosition + Vector2.right * SequencerButton.BUTTON_WIDTH * playbackRatio * MusicSequencer.BEATS_PER_SONG;
		}
	}
}
