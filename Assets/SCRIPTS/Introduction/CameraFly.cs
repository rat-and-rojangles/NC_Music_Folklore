using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFly : MonoBehaviour {

	public float speed;

	public InterpolationMethod interpolationMethod;

	public void FlyToPoint (Vector3 target) {
		StopAllCoroutines ();
		StartCoroutine (Fly (target));
	}

	private IEnumerator Fly (Vector3 target) {
		Vector3 initialPosition = transform.position;
		Timer timer = new Timer (Vector3.Distance (initialPosition, target) / speed);
		StartCoroutine (timer.StartTicking ());
		while (!timer.complete) {
			transform.position = Interpolation.Interpolate (initialPosition, target, timer.ratio, interpolationMethod);
			yield return null;
		}
	}

	public MusicSequencer sequencer;

	public void EnableRap () {
		sequencer.rapEnabled = true;
	}
}
