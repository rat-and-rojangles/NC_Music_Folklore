using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RhymeButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {

	private static HashSet<RhymeButton> m_currentPointedSet = null;
	private static HashSet<RhymeButton> currentPointedSet {
		get {
			if (m_currentPointedSet == null) {
				m_currentPointedSet = new HashSet<RhymeButton> ();
			}
			return m_currentPointedSet;
		}
	}
	private static RhymeButton mousedOver {
		get {
			RhymeButton result = null;
			foreach (RhymeButton rb in currentPointedSet) {
				result = rb;
			}
			return result;
		}
	}

	void OnDestroy () {
		m_currentPointedSet = null;
	}

	[SerializeField]
	private RhymeLyrics myRhymeLyrics;

	private RhymeLine m_rhymeLine = null;
	public RhymeLine rhymeLine {
		get { return m_rhymeLine; }
		set {
			m_rhymeLine = value;
			Refresh ();
		}
	}

	private RectTransform m_rectTransform = null;
	public RectTransform rectTransform {
		get {
			if (m_rectTransform == null) {
				m_rectTransform = GetComponent<RectTransform> ();
			}
			return m_rectTransform;
		}
	}

	[SerializeField]
	private Text text;

	[SerializeField]
	private Image image;

	private const float FLASH_CYCLE_DURATION = 0.5f;

	private static Color otherColor = Color.Lerp (Color.yellow, Color.white, 0.5f);

	private void Refresh () {
		if (rhymeLine != null) {
			text.text = rhymeLine.text;
			image.color = Color.white;
		}
		else {
			text.text = "EMPTY";
			image.color = Color.gray;
		}
	}

	private bool dragging = false;

	public void OnBeginDrag (PointerEventData eventData) {
		if (!myRhymeLyrics.sequencerPlaying) {
			dragging = true;
			BeginFlash ();
			LyricDragCursor.current.Activate (this);
		}
	}

	public void OnDrag (PointerEventData eventData) {
		// OnScreenConsole.Log (mousedOver);
	}

	public void OnEndDrag (PointerEventData eventData) {
		if (dragging) {
			dragging = false;
			EndFlash ();
			LyricDragCursor.current.Deactivate ();
			if (mousedOver != null && mousedOver != this) {
				RhymeLine temp = rhymeLine;
				rhymeLine = mousedOver.rhymeLine;
				mousedOver.rhymeLine = temp;
			}
		}
	}


	public void OnPointerEnter (PointerEventData eventData) {
		if (Input.GetMouseButton (0) && !myRhymeLyrics.sequencerPlaying) {
			BeginFlash ();
		}
		currentPointedSet.Add (this);
	}

	public void OnPointerExit (PointerEventData eventData) {
		if (!dragging) {
			EndFlash ();
		}
		currentPointedSet.Remove (this);
	}

	private void BeginFlash () {
		StartCoroutine (Flash ());
	}
	private void EndFlash () {
		StopAllCoroutines ();
		Refresh ();
	}

	private float cycleValue {
		get {
			return (Mathf.Sin ((Time.time) / FLASH_CYCLE_DURATION * 2f * Mathf.PI) + 1f) / 2f;
		}
	}

	private IEnumerator Flash () {
		Color initialColor = image.color;
		while (true) {
			image.color = Color.Lerp (initialColor, otherColor, cycleValue);
			yield return null;
		}
	}
}