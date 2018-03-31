using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerSongSerialization : ScriptableObject {
	public float tempo;
	public SequencerClip [] track0;
	public SequencerClip [] track1;
	public SequencerClip [] track2;
	public SequencerClip [] track3;
	public RapSerialization rapLyrics;
}
