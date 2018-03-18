using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureShift : MonoBehaviour {
	public Material material;
	public Vector2 offsetPerSecond;

	void Update () {
		material.mainTextureOffset += offsetPerSecond * Time.deltaTime;
	}
}
