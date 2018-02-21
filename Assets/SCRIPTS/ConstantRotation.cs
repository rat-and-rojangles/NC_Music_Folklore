using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bobbing powerup kind of thing. This expects the local position of the object this is attached to to be zero
/// </summary>
public class ConstantRotation : MonoBehaviour {
	public Vector3 eulersPerSecond;

	void Update () {
		transform.Rotate (eulersPerSecond * Time.deltaTime);
	}
}
