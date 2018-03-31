using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhymeLyrics : MonoBehaviour {

	public int numberOfLinesInSong;

	private RhymeButton [] lines;

	[SerializeField]
	[Tooltip ("should be child of lyrics notebook")]
	private GameObject buttonPrototype;

	[SerializeField]
	private Transform notebookParent;

	[SerializeField]
	private Transform libraryParent;

	[SerializeField]
	private MusicSequencer sequencer;

	public bool sequencerPlaying {
		get { return sequencer.isPlaying; }
	}

	public void AttemptToToggle () {
		if (IsValid ()) {
			Save ();
			sequencer.TogglePlayback ();
		}
	}

	private bool RhymesWithUpperOrLower (int index) {
		if (index > 0) {
			if (RhymeLine.Rhymes (lines [index].rhymeLine, lines [index - 1].rhymeLine)) {
				return true;
			}
		}

		if (index < lines.Length - 1) {
			if (RhymeLine.Rhymes (lines [index].rhymeLine, lines [index + 1].rhymeLine)) {
				return true;
			}
		}

		return false;
	}

	/// <summary>
	/// Is this a valid song?
	/// </summary>
	public bool IsValid () {
		for (int x = 0; x < lines.Length; x++) {
			if (!RhymesWithUpperOrLower (x)) {
				return false;
			}
		}
		return true;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			OnScreenConsole.Log (IsValid ());
		}
	}

	void Start () {
		List<RhymeButton> tempButtonList = new List<RhymeButton> ();
		RhymeButton clone = buttonPrototype.GetComponent<RhymeButton> ();
		clone.rhymeLine = null;
		tempButtonList.Add (clone);
		for (int x = 1; x < numberOfLinesInSong; x++) {
			clone = Instantiate (buttonPrototype, notebookParent).GetComponent<RhymeButton> ();
			clone.rhymeLine = null;
			tempButtonList.Add (clone);
		}
		lines = tempButtonList.ToArray ();

		foreach (RhymeLine rl in GameUtility.rhymeLines) {
			Instantiate (buttonPrototype, libraryParent).GetComponent<RhymeButton> ().rhymeLine = rl;
		}
	}

	public void Save () {
		GameUtility.rapLyrics.rhymeLines = new RhymeLine [lines.Length];
		for (int x = 0; x < lines.Length; x++) {
			GameUtility.rapLyrics.rhymeLines [x] = lines [x].rhymeLine;
		}
	}

}
