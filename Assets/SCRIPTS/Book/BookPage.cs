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

	/// <summary>
	/// Fill out this page with data on an item.
	/// </summary>
	public void Fill (CollectibleObject collectibleObject) {
		if (collectibleObject.discovered) {
			titleField.text = collectibleObject.title;
			textField.text = collectibleObject.text;
			iconField.sprite = collectibleObject.icon;
		}
		else {
			titleField.text = "???";
			textField.text = "";
			iconField.sprite = collectibleObject.iconBlurred;
		}
	}
}
