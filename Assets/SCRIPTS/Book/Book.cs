using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour {
	private CollectibleObject [] m_collectibleObjects = null;
	private CollectibleObject [] collectibleObjects {
		get {
			if (m_collectibleObjects == null) {
				m_collectibleObjects = GameUtility.GetAllCollectibleObjects (startingNumberUnlocked);
			}
			return m_collectibleObjects;
		}
	}

	/// <summary>
	/// The number of two-page spreads the book has.
	/// </summary>
	public int spreadCount {
		get {
			return Mathf.CeilToInt (collectibleObjects.Length * 0.5f);
		}
	}

	/// <summary>
	/// Current spread opened.
	/// </summary>
	private int currentSpread = 0;

	[SerializeField]
	private int startingNumberUnlocked;

	[SerializeField]
	private BookPage leftPage;
	[SerializeField]
	private BookPage rightPage;

	[SerializeField]
	private Button nextButton;
	[SerializeField]
	private Button previousButton;

	/// <summary>
	/// Refreshes the active state of the next and previous buttons.
	/// </summary>
	public void RefreshButtons () {
		previousButton.interactable = currentSpread != 0;
		nextButton.interactable = currentSpread < spreadCount;
	}

	public void PreviousPage () {
		TurnToSpread (currentSpread - 1);
	}
	public void NextPage () {
		TurnToSpread (currentSpread + 1);
	}

	private void TurnToSpread (int spreadNumber) {
		currentSpread = spreadNumber;
		leftPage.Fill (collectibleObjects [currentSpread * 2]);
		if (1 + currentSpread * 2 < collectibleObjects.Length) {
			rightPage.Fill (collectibleObjects [1 + currentSpread * 2]);
		}
		else {
			rightPage.Fill (GameUtility.blankPageObject);
		}
		RefreshButtons ();
	}

	/// <summary>
	/// Open the book to the page with the object you specify.
	/// </summary>
	public void OpenBook (CollectibleObject openToThisPage) {
		if (!gameObject.activeSelf) {
			int index = 0;
			while (index < collectibleObjects.Length) {
				if (collectibleObjects [index] == openToThisPage) {
					TurnToSpread (index / 2);
					index = collectibleObjects.Length;
				}
			}
			gameObject.SetActive (true);
		}
	}

	/// <summary>
	/// Open the book to the last page you were on.
	/// </summary>
	public void OpenBook () {
		if (!gameObject.activeSelf) {
			RefreshButtons ();
			gameObject.SetActive (true);
		}
	}

	public void CloseBook () {
		// later: make this cooler
		gameObject.SetActive (false);
	}
}
