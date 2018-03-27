using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequencerTrackUI : MonoBehaviour {

	[SerializeField]
	private MusicSequencer mySequencer;

	[SerializeField]
	public Color color;

	[SerializeField]
	private SequencerTrack myTrack;

	[SerializeField]
	public SequencerButton [] beatButtons;

	private SequencerClipButton [] clipButtons = new SequencerClipButton [MusicSequencer.BEATS_PER_SONG];

	public void SequencerButtonClicked (SequencerButton sequencerButton) {
		int beatIndex = -1;
		for (int x = 0; x < MusicSequencer.BEATS_PER_SONG; x++) {
			if (sequencerButton == beatButtons [x]) {
				beatIndex = x;
				x = MusicSequencer.BEATS_PER_SONG;
			}
		}
		Insert (beatIndex);
	}

	private bool Insert (int beatIndex) {
		bool successful = myTrack.Insert (mySequencer.currentClipSelected, beatIndex);
		if (successful) {
			RectTransform clone = Instantiate (mySequencer.clipButtonPrefab, transform, true).GetComponent<RectTransform> ();
			clone.localScale = Vector3.one;
			clone.sizeDelta = new Vector2 (mySequencer.currentClipSelected.length * SequencerButton.BUTTON_WIDTH, clone.sizeDelta.y);
			clone.anchoredPosition = Vector2.right * SequencerButton.BUTTON_WIDTH * beatIndex;

			clone.offsetMin = new Vector2 (clone.offsetMin.x, 0f);
			clone.offsetMax = new Vector2 (clone.offsetMax.x, 0f);

			clone.SetAsLastSibling ();

			SequencerClipButton cloneClip = clone.GetComponent<SequencerClipButton> ();
			cloneClip.myTrackUI = this;
			cloneClip.beatIndexInTrack = beatIndex;
			cloneClip.button.image.sprite = mySequencer.currentClipSelected.playlistSprite;

			ColorBlock tempColorBlock = cloneClip.button.colors;
			tempColorBlock.normalColor = color;
			Color highlightedColor = Color.Lerp (color, Color.white, 0.5f);
			highlightedColor = new Color (highlightedColor.r, highlightedColor.g, highlightedColor.b, 0.75f);
			tempColorBlock.highlightedColor = highlightedColor;
			cloneClip.button.colors = tempColorBlock;

			clipButtons [beatIndex] = cloneClip;

			UpdateButtonInteractibility ();
		}
		return successful;
	}

	/// <summary>
	/// Called by SequencerClipButtons
	/// </summary>
	public bool RemoveAt (int beatIndex) {
		bool successful = myTrack.RemoveAt (beatIndex);
		if (successful) {
			Destroy (clipButtons [beatIndex].gameObject);
			clipButtons [beatIndex] = null;
			UpdateButtonInteractibility ();
		}
		return successful;
	}

	public void UpdateButtonInteractibility () {
		if (mySequencer.isPlaying) {
			foreach (SequencerButton sqb in beatButtons) {
				sqb.button.interactable = false;
			}
			foreach (SequencerClipButton scb in clipButtons) {
				if (scb != null) {
					scb.button.interactable = false;
				}
			}
		}
		else {
			int disableThisMany = 0;
			for (int x = 0; x < MusicSequencer.BEATS_PER_SONG; x++) {
				if (myTrack.clips [x] != null) {
					disableThisMany = myTrack.clips [x].length;
				}
				if (disableThisMany > 0) {
					beatButtons [x].button.interactable = false;
					disableThisMany--;
				}
				else {
					beatButtons [x].button.interactable = true;
				}
			}
			foreach (SequencerClipButton scb in clipButtons) {
				if (scb != null) {
					scb.button.interactable = true;
				}
			}
		}
	}
}
