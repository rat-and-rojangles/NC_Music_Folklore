using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenConsole : MonoBehaviour {

	public Color m_textColor;

	private static OnScreenConsole m_staticRef;
	private static OnScreenConsole staticRef {
		get {
			if (m_staticRef == null) {
				CreateStaticRef ();
			}
			return m_staticRef;
		}
	}

	private static void CreateStaticRef () {
		GameObject empty = new GameObject ();
		empty.name = "On Screen Console";
		m_staticRef = empty.AddComponent<OnScreenConsole> ();
		m_staticRef.m_textColor = Color.white;
	}

	public static Color textColor {
		get {
			return staticRef.m_textColor;
		}
		set {
			staticRef.m_textColor = value;
		}
	}

	private string text = "";

	void Awake () {
		m_staticRef = this;
	}
	void OnDestroy () {
		m_staticRef = null;
	}

	/// <summary>
	/// Write a persistent message to the screen.
	/// </summary>
	public static void Log (object message) {
		staticRef.text += message.ToString () + "\n";
		if (staticRef.text.Length > 1000) {
			staticRef.text = staticRef.text.Substring (staticRef.text.Length - 1000);
		}
	}

	public static void ClearConsole () {
		staticRef.text = "";
	}

	void OnGUI () {
		WriteGUI ();
	}

	private void WriteGUI () {
		int w = Screen.width, h = Screen.height;
		GUIStyle style = new GUIStyle ();

		style.alignment = TextAnchor.LowerLeft;
		style.fontSize = h / 12;
		style.normal.textColor = staticRef.m_textColor;

		Rect rect = new Rect (0, h - style.fontSize * 2, w, h / 4);

		GUI.Label (rect, text, style);
	}
}
