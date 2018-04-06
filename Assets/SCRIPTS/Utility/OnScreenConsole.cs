using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenConsole : MonoBehaviour {

	public Color m_textColor;

	private static OnScreenConsole m_current;
	private static OnScreenConsole current {
		get {
			if (m_current == null) {
				Createcurrent ();
			}
			return m_current;
		}
	}

	private static void Createcurrent () {
		GameObject empty = new GameObject ();
		empty.name = "On Screen Console";
		m_current = empty.AddComponent<OnScreenConsole> ();
		m_current.m_textColor = Color.white;
	}

	public static Color textColor {
		get {
			return current.m_textColor;
		}
		set {
			current.m_textColor = value;
		}
	}

	private string text = "";

	void Awake () {
		m_current = this;
	}
	void OnDestroy () {
		m_current = null;
	}

	/// <summary>
	/// Write a persistent message to the screen.
	/// </summary>
	public static void Log (object message) {
		string messagePrime = message == null ? "null" : message.ToString ();
		current.text += messagePrime.ToString () + "\n";
		if (current.text.Length > 1000) {
			current.text = current.text.Substring (current.text.Length - 1000);
		}
	}

	public static void ClearConsole () {
		current.text = "";
	}

	void OnGUI () {
		WriteGUI ();
	}

	private void WriteGUI () {
		int w = Screen.width, h = Screen.height;
		GUIStyle style = new GUIStyle ();

		style.alignment = TextAnchor.LowerLeft;
		style.fontSize = h / 12;
		style.normal.textColor = current.m_textColor;

		Rect rect = new Rect (0, h - style.fontSize * 2, w, h / 4);

		GUI.Label (rect, text, style);
	}
}
