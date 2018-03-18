using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequencerButton : MonoBehaviour {

	public const float BUTTON_WIDTH = 37f;

	[SerializeField]
	public SequencerTrackUI myTrackUI;

	public void AttemptAddClipHere () {
		myTrackUI.SequencerButtonClicked (this);
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
