using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour {

	public static int objectCountInScene = 0;

	private CollectibleObjectSerialization collectibleObjectSerialization;

	[SerializeField]
	private GameObject glow;
	[SerializeField]
	private SineBob sineBob;

	[SerializeField]
	private Renderer[] renderersWithTexture;

	[SerializeField]
	private BoxCollider m_boxCollider;

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


	public void Initialize (CollectibleObjectSerialization collectibleObjectSerialization, Vector3 localScale, BoxCollider boxCollider) {
		objectCountInScene++;
		transform.localScale = new Vector3 (localScale.x, 1f, localScale.z);
		this.collectibleObjectSerialization = collectibleObjectSerialization;
		foreach (Renderer r in renderersWithTexture) {
			r.material.mainTexture = collectibleObject.icon.texture;
		}
		m_boxCollider.center = new Vector3 (boxCollider.center.x, 0.001f, boxCollider.center.z);
		m_boxCollider.size = boxCollider.size;
	}

	void OnMouseDown () {
		if (glow.activeSelf) {
			glow.SetActive (false);
			sineBob.bobbing = false;
			objectCountInScene--;
		}

		collectibleObject.discovered = true;
		book.OpenBook (collectibleObject);
	}
}
