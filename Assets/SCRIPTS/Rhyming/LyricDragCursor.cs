using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LyricDragCursor : MonoBehaviour {

	private Color halfWhite = new Color (1f, 1f, 1f, 0.5f);
	private Color halfGray = new Color (0.5f, 0.5f, 0.5f, 0.5f);


	[SerializeField]
	private Text text;
	[SerializeField]
	private Image image;

	[SerializeField]
	private GameObject visual;

	public void Activate (RhymeButton rhymeButton) {
		if (rhymeButton.rhymeLine != null) {
			text.text = rhymeButton.rhymeLine.text;
			image.color = halfWhite;
		}
		else {
			text.text = "EMPTY";
			image.color = halfGray;
		}
		visual.SetActive (true);
	}
	public void Deactivate () {
		visual.SetActive (false);
	}

	private static LyricDragCursor m_current = null;
	public static LyricDragCursor current {
		get { return m_current; }
	}

	void Awake () {
		m_current = this;
	}
	void OnDestroy () {
		m_current = null;
	}

	private RectTransform m_rectTransform = null;
	private RectTransform rectTransform {
		get {
			if (m_rectTransform == null) {
				m_rectTransform = GetComponent<RectTransform> ();
			}
			return m_rectTransform;
		}
	}

	[SerializeField]
	private RectTransform mainCanvasRect;

	void Update () {
		rectTransform.anchoredPosition = MousePositionToCanvasSpace ();
	}

	public Vector2 MousePositionToCanvasSpace () {
		Vector2 viewportPos = Camera.main.ScreenToViewportPoint (Input.mousePosition);
		return new Vector2 (((viewportPos.x * mainCanvasRect.sizeDelta.x) - (mainCanvasRect.sizeDelta.x * 0.5f)), ((viewportPos.y * mainCanvasRect.sizeDelta.y) - (mainCanvasRect.sizeDelta.y * 0.5f)));
	}
}
