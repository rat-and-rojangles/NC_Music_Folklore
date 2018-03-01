using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class CollectorCameraVelocity : MonoBehaviour {

	public float sensitivity = 1f;
	public float zoomStrength = 1f;

	private Rigidbody m_rigidbody;
	private new Rigidbody rigidbody {
		get {
			if (m_rigidbody == null) {
				m_rigidbody = GetComponent<Rigidbody> ();
			}
			return m_rigidbody;
		}
	}

	private Vector3 GetDragVelocity () {
		Vector3 rawDrag = -(Vector3.right * Input.GetAxis ("Mouse X") + Vector3.forward * Input.GetAxis ("Mouse Y")) * sensitivity;
		rawDrag *= transform.position.y / 25f;
		return rawDrag;
	}

	void Update () {
		if (Input.GetMouseButton (1)) {
			rigidbody.velocity = GetDragVelocity ();
		}
		rigidbody.velocity += Vector3.down * Input.GetAxis ("Mouse ScrollWheel") * zoomStrength;
	}
}
