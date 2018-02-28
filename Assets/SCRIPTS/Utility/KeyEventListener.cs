using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyEventListener : MonoBehaviour {
	[SerializeField]
	private KeyCode keyCode;

	[SerializeField]
	private UnityEvent onKeyDown;
	[SerializeField]
	private UnityEvent onKeyUp;

	void Start () {
		StartCoroutine (ListenLoop ());
	}

	private IEnumerator ListenLoop () {
		while (true) {
			if (Input.GetKeyDown (keyCode)) {
				onKeyDown.Invoke ();
			}
			if (Input.GetKeyUp (keyCode)) {
				onKeyUp.Invoke ();
			}
		}
	}
}