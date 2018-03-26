using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWalls : MonoBehaviour {

	[SerializeField]
	private GameObject[] walls;
	[SerializeField]
	private GameObject ceiling;

	void Start () {
		Vector2 minXZ = new Vector2 (float.MaxValue, float.MaxValue);
		Vector2 maxXZ = new Vector2 (float.MinValue, float.MinValue);
		foreach (GameObject wall in walls) {
			wall.GetComponent<MeshRenderer> ().enabled = false;
			Vector3 tempScale = wall.transform.localScale;
			tempScale.y = ceiling.transform.position.y * 2f;
			wall.transform.localScale = tempScale;

			minXZ.x = Mathf.Min (minXZ.x, wall.transform.position.x);
			minXZ.y = Mathf.Min (minXZ.y, wall.transform.position.z);
			maxXZ.x = Mathf.Max (maxXZ.x, wall.transform.position.x);
			maxXZ.y = Mathf.Max (maxXZ.y, wall.transform.position.z);
		}

		Vector3 tempPos = ceiling.transform.position;
		tempPos.x = (maxXZ.x + minXZ.x) * 0.5f;
		tempPos.z = (maxXZ.y + minXZ.y) * 0.5f;
		ceiling.transform.position = tempPos;
		Vector3 tempScale2 = ceiling.transform.localScale;
		tempScale2.x = (maxXZ.x - minXZ.x);
		tempScale2.z = (maxXZ.y - minXZ.y);
		ceiling.transform.localScale = tempScale2;
	}

}
