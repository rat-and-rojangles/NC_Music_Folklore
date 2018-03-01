using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPage : MonoBehaviour {
	[SerializeField]
	private Text titleField;

	[SerializeField]
	private Text textField;

	[SerializeField]
	private Image iconField;

	[SerializeField]
	private Button speakerButton;

	private AudioClip m_voiceOver;
	public AudioClip voiceOver {
		get { return m_voiceOver; }
	}

	/// <summary>
	/// Fill out this page with data on an item.
	/// </summary>
	public void Fill (CollectibleObject collectibleObject) {
		if (collectibleObject.title.Length == 0) {  // blank page
			titleField.text = collectibleObject.title;
			textField.text = collectibleObject.text;
			iconField.sprite = collectibleObject.icon;
			m_voiceOver = null;
			speakerButton.gameObject.SetActive (false);
		}
		else if (collectibleObject.discovered) {
			titleField.text = collectibleObject.title;
			textField.text = collectibleObject.text;
			iconField.sprite = collectibleObject.icon;
			m_voiceOver = collectibleObject.voiceOver;
			speakerButton.gameObject.SetActive (true);
		}
		else {
			titleField.text = "???";
			textField.text = "";
			iconField.sprite = collectibleObject.iconBlurred;
			m_voiceOver = null;
			speakerButton.gameObject.SetActive (false);
		}
	}
}
