using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectTemplate : MonoBehaviour {

	[SerializeField]
	private CollectibleObjectSerialization targetObject;

	void Start () {
		GameObject clone = Instantiate (GameUtility.mapObjectTemplate, new Vector3 (transform.position.x, 5.1f, transform.position.z), Quaternion.identity);
		clone.GetComponentInChildren<MapObject> ().Initialize (targetObject, transform.localScale, GetComponent<BoxCollider> ());
		Destroy (gameObject);
	}

	[ContextMenu ("Show Image")]
	void ShowImage () {
		if (targetObject != null) {
			MeshRenderer meshRenderer = GetComponent<MeshRenderer> ();
			Material freshMaterial = new Material (GameUtility.itemMaterialEditorOnly);
			freshMaterial.mainTexture = targetObject.icon.texture;
			meshRenderer.material = freshMaterial;
		}
	}

}
