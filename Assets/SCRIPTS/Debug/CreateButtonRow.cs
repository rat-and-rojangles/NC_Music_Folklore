using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButtonRow : MonoBehaviour {
	public GameObject prototype;
	[ContextMenu ("Create Row")]
	public void CreateRow () {
		for (int x = 1; x < 32; x++) {
			RectTransform clone = Instantiate (prototype, transform, true).GetComponent<RectTransform> ();
			clone.anchoredPosition += Vector2.right * clone.sizeDelta.x * x;
		}
	}

	[ContextMenu ("configure")]
	public void Configure () {
		SequencerTrackUI trackUI = GetComponent<SequencerTrackUI> ();
		trackUI.color = GetComponent<Image> ().color;
		trackUI.beatButtons = new SequencerButton [MusicSequencer.BEATS_PER_SONG];
		foreach (Button b in GetComponentsInChildren<Button> ()) {
			SequencerButton newSequencerButton = b.GetComponent<SequencerButton> ();
			if (newSequencerButton == null) {
				newSequencerButton = b.gameObject.AddComponent<SequencerButton> ();
			}

			newSequencerButton.myTrackUI = trackUI;
			trackUI.beatButtons [b.transform.GetSiblingIndex ()] = newSequencerButton;
		}
	}

	public void Howl () {
		OnScreenConsole.Log (Random.value);
	}
}
