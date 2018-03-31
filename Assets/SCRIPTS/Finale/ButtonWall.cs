using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWall : MonoBehaviour {
	public Vector3 nextCameraTarget;

	public void FlyCamera () {
		foreach (Button3D b3 in GetComponentsInChildren<Button3D> ()) {
			b3.enabled = false;
		}
		Camera.main.GetComponent<CameraFly> ().FlyToPoint (nextCameraTarget);
	}

	[ContextMenu ("Set Cam current to next")]
	void asgasdf () {
		nextCameraTarget = Camera.main.transform.position;
	}
}
