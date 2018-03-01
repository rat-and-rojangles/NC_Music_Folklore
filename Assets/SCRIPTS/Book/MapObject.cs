using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour {

	[SerializeField]
	private CollectibleObjectSerialization collectibleObjectSerialization;

	[SerializeField]
	private GameObject particles;
	[SerializeField]
	private SineBob sineBob;

	private CollectibleObject m_collectibleObject = null;
	private CollectibleObject collectibleObject {
		get {
			if (m_collectibleObject == null) {
				m_collectibleObject = book.GetCollectibleObjectFromSerialization (collectibleObjectSerialization);
			}
			return m_collectibleObject;
		}
	}

	private Book m_book;
	private Book book {
		get {
			if (m_book == null) {
				m_book = GameObject.FindGameObjectWithTag ("MainCanvas").GetComponentInChildren<Book> (true);
			}
			return m_book;
		}
	}


	void Start () {
		GetComponent<MeshRenderer> ().material.mainTexture = collectibleObject.icon.texture;
	}

	void OnMouseDown () {
		particles.SetActive (false);
		sineBob.bobbing = false;
		collectibleObject.discovered = true;
		book.OpenBook (collectibleObject);
	}
}
