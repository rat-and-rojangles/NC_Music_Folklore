using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveNavigation : MonoBehaviour {

	Navigation noNavigation {
		get {
			Navigation temp = Navigation.defaultNavigation;
			temp.mode = Navigation.Mode.None;
			return temp;
		}
	}

	[ContextMenu ("change all buttons to no nav")]
	public void Esketit () {
		foreach (Button b in GetComponentsInChildren<Button> ()) {
			b.navigation = noNavigation;
		}
	}
}
