using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// One entity in the book corresponding to the real world object. This should be a UI button
/// </summary>
public class CollectibleItemBookEntry : MonoBehaviour {

	// on click: show data
	// title is game object name

	public AudioClip voiceover;

	/// <summary>
	/// Detailed text on the object.
	/// </summary>
	public string text;
}
