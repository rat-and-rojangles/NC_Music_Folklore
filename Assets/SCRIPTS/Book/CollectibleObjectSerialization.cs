using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An object that can be collected on the map and viewed in the book.
/// </summary>
public class CollectibleObjectSerialization : ScriptableObject {
	[SerializeField]
	private string m_title;
	public string title {
		get { return m_title; }
	}

	[SerializeField]
	[TextArea]
	private string m_text;
	public string text {
		get { return m_text; }
	}

	[SerializeField]
	private Sprite m_icon;
	public Sprite icon {
		get { return m_icon; }
	}

	[SerializeField]
	private Sprite m_iconBlurred;
	public Sprite iconBlurred {
		get { return m_iconBlurred; }
	}
}
