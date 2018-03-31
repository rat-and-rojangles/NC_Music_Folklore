using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhymeLine : ScriptableObject {

	/// <summary>
	/// Do both of these lines rhyme?
	/// </summary>
	public static bool Rhymes (RhymeLine a, RhymeLine b) {
		if (a == null || b == null) {
			return false;
		}
		else {
			return a.rhymeIndex == b.rhymeIndex;
		}
	}

	[SerializeField]
	[TextArea]
	private string m_text;
	public string text {
		get { return m_text; }
	}

	[SerializeField]
	private int m_rhymeIndex;
	public int rhymeIndex {
		get { return m_rhymeIndex; }
	}

	[SerializeField]
	private AudioClip m_audio;
	public AudioClip audio {
		get { return m_audio; }
	}
}
