using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineBobUI : MonoBehaviour {

	[Tooltip ("Max vertical displacement when bobbing in pixels.")]
	public float displacement = 10f;

	[Tooltip ("Number of seconds it takes for this to go up then down.")]
	public float cycleDuration = 1f;

	void OnDisable () {
		rectTransform.anchoredPosition = Vector2.zero;
	}

	private RectTransform m_rectTransform;
	private RectTransform rectTransform {
		get {
			if (m_rectTransform == null) {
				m_rectTransform = GetComponent<RectTransform> ();
			}
			return m_rectTransform;
		}
	}

	void Update () {
		rectTransform.anchoredPosition = displacement * Vector2.up * Mathf.Sin ((Time.time) / cycleDuration * 2f * Mathf.PI);
	}
}
