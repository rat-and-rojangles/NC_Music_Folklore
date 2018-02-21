using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorCameraControl : MonoBehaviour {

	public float sensitivity = 1f;
	public float followStrength = 1f;
	public float verticalIncrement = 1f;
	private Vector3 idealPosition;

	private Vector3 camMouseOffset;

	void Start () {
		idealPosition = Camera.main.transform.position;
	}

	private Vector3 mouseWorldPoint {
		get {
			Vector2 mousePos = Input.mousePosition;
			return Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, Camera.main.nearClipPlane));
		}
	}

	private void MoveIdealPositionWithMouse () {
		Vector3 mouseWorld = mouseWorldPoint;
		idealPosition = new Vector3 (mouseWorld.x - camMouseOffset.x, mouseWorld.y - camMouseOffset.y, idealPosition.z);
	}

	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			RaycastHit camHit, mouseHit;
			Physics.Raycast (Camera.main.transform.position, Vector3.down, out camHit);
			Physics.Raycast (mouseWorldPoint, Vector3.down, out mouseHit);
			camMouseOffset = camHit.point - mouseHit.point;
		}
		if (Input.GetMouseButton (1)) {
			// idealPosition -= (Vector3.right * Input.GetAxis ("Mouse X") + Vector3.forward * Input.GetAxis ("Mouse Y")) * sensitivity;
			MoveIdealPositionWithMouse ();
		}

		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		if (scroll > 0.01f) {
			idealPosition -= Vector3.up * verticalIncrement;
		}
		else if (scroll < -0.01f) {
			idealPosition -= Vector3.down * verticalIncrement;
		}

		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, idealPosition, followStrength * Time.deltaTime);
	}
}
