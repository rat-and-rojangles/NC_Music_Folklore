using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectorSceneChangerButton : MonoBehaviour {

	[SerializeField]
	private Image buttonImage;
	[SerializeField]
	private GameObject textObject;

	void Update () {
		buttonImage.enabled = MapObject.objectCountInScene == 0;
		textObject.SetActive (buttonImage.enabled);
	}

	void Awake () {
		MapObject.objectCountInScene = 0;
	}

	public void ChangeScene (string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
	public void ChangeScene (int sceneBuildIndex) {
		SceneManager.LoadScene (sceneBuildIndex);
	}
}
