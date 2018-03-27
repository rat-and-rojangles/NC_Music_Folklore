using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeAllButtonNavigatino : MonoBehaviour {

	/// <summary>
	/// Use this method to get all loaded objects of some type, including inactive objects. 
	/// This is an alternative to Resources.FindObjectsOfTypeAll (returns project assets, including prefabs), and GameObject.FindObjectsOfTypeAll (deprecated).
	/// </summary>
	public static T[] FindObjectsOfTypeAll<T> () {
		List<T> results = new List<T> ();
		for (int i = 0; i < SceneManager.sceneCount; i++) {
			var s = SceneManager.GetSceneAt (i);
			if (s.isLoaded) {
				var allGameObjects = s.GetRootGameObjects ();
				for (int j = 0; j < allGameObjects.Length; j++) {
					var go = allGameObjects[j];
					results.AddRange (go.GetComponentsInChildren<T> (true));
				}
			}
		}
		return results.ToArray ();
	}

	[ContextMenu ("fix")]
	void Fix () {
		Navigation whatWeWant = Navigation.defaultNavigation;
		whatWeWant.mode = Navigation.Mode.None;
		foreach (Button b in FindObjectsOfTypeAll<Button> ()) {
			b.navigation = whatWeWant;
		}
	}
}
