using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequencerClipButton : MonoBehaviour {
	public int beatIndexInTrack;
	public SequencerTrackUI myTrackUI;

	public void RemoveSelf () {
		myTrackUI.RemoveAt (beatIndexInTrack);
	}

	private Button m_button;
	public Button button {
		get {
			if (m_button == null) {
				m_button = GetComponent<Button> ();
			}
			return m_button;
		}
	}
}
