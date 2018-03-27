using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineBob : MonoBehaviour {

	[System.NonSerialized]
	public bool bobbing = true;
	private bool shouldBeFloating = true;

	[Tooltip ("Max vertical displacement when bobbing.")]
	public float displacement = 1f;

	[Tooltip ("Number of seconds it takes for this to go up then down.")]
	public float cycleDuration = 1f;

	void OnMouseOver () {
		shouldBeFloating = false;
	}

	void LateUpdate () {
		if (shouldBeFloating) {
			if (bobbing) {
				transform.localPosition = displacement * Vector3.up * Mathf.Sin ((Time.time) / cycleDuration * 2f * Mathf.PI);
			}
			else {
				transform.localPosition = Vector3.zero;
			}
		}
		else {
			transform.localPosition = Vector3.up * displacement;
		}
		shouldBeFloating = true;
	}
}
