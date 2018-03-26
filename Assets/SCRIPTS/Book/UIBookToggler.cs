using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBookToggler : MonoBehaviour {

	[SerializeField]
	private Sprite bookActivateSprite;
	[SerializeField]
	private Sprite bookDeactivateSprite;

	[SerializeField]
	private Book book;

	[SerializeField]
	private UnityEngine.UI.Image buttonImage;

	public void OnClick () {
		if (book.gameObject.activeSelf) {
			book.CloseBook ();
		}
		else {
			book.OpenBook ();
		}
	}

	void Update () {
		if (!book.gameObject.activeSelf) {
			buttonImage.sprite = bookActivateSprite;
		}
		else {
			buttonImage.sprite = bookDeactivateSprite;
		}
	}
}
