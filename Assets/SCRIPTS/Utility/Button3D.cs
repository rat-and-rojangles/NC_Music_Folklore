﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour {
	public UnityEvent onClick;

	void OnMouseDown () {
		if (enabled) {
			onClick.Invoke ();
		}
	}
}
