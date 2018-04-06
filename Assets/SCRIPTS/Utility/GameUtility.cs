using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Static methods useful to the game.
/// </summary>
public static class GameUtility {

	private static SequencerSongSerialization m_mySavedSong = null;
	public static SequencerSongSerialization mySavedSong {
		get {
			if (m_mySavedSong == null) {
				m_mySavedSong = Resources.Load<SequencerSongSerialization> ("MySong");
			}
			return m_mySavedSong;
		}
	}

	private static RapSerialization m_rapLyrics = null;
	public static RapSerialization rapLyrics {
		get {
			if (m_rapLyrics == null) {
				m_rapLyrics = Resources.Load<RapSerialization> ("RapLyrics");
			}
			return m_rapLyrics;
		}
	}

	private static RhymeLine [] m_rhymeLines = null;
	public static RhymeLine [] rhymeLines {
		get {
			if (m_rhymeLines == null) {
				List<RhymeLine> tempList = new List<RhymeLine> (Resources.LoadAll<RhymeLine> ("RhymeLines"));
				tempList.Shuffle ();
				m_rhymeLines = tempList.ToArray ();
			}
			return m_rhymeLines;
		}
	}

	private static GameObject m_mapObjectTemplate = null;
	public static GameObject mapObjectTemplate {
		get {
			if (m_mapObjectTemplate == null) {
				m_mapObjectTemplate = Resources.Load<GameObject> ("MapObjectTemplate");
			}
			return m_mapObjectTemplate;
		}
	}

	private static SequencerClip [] m_allSequencerClips = null;
	/// <summary>
	/// All sequencer clips in the resources folder, sorted by length then name.
	/// </summary>
	/// <returns></returns>
	public static SequencerClip [] allSequencerClips {
		get {
			if (m_allSequencerClips == null) {
				m_allSequencerClips = Resources.LoadAll<SequencerClip> ("SequencerClips");
			}
			List<SequencerClip> tempList = new List<SequencerClip> (m_allSequencerClips);
			tempList.Sort (CompareSequencerClips);
			return tempList.ToArray ();
		}
	}
	private static int CompareSequencerClips (SequencerClip a, SequencerClip b) {
		if (a.length == b.length) {
			return a.name.CompareTo (b.name);
		}
		else {
			return a.length - b.length;
		}
	}

	private static CollectibleObjectCatalog m_collectibleObjectCatalog;
	private static CollectibleObjectCatalog collectibleObjectCatalog {
		get {
			if (m_collectibleObjectCatalog == null) {
				m_collectibleObjectCatalog = Resources.Load<CollectibleObjectCatalog> ("CollectibleObjectCatalog");
			}
			return m_collectibleObjectCatalog;
		}
	}
	public static CollectibleObject [] GetAllCollectibleObjects (int numberDiscovered) {
		return collectibleObjectCatalog.GetAllCollectibleObjects (numberDiscovered);
	}

	private static CollectibleObject m_blankPageObject;
	/// <summary>
	/// For filling out the data on a blank page.
	/// </summary>
	public static CollectibleObject blankPageObject {
		get {
			if (m_blankPageObject == null) {
				m_blankPageObject = new CollectibleObject (collectibleObjectCatalog.blankPage);
			}
			return m_blankPageObject;
		}
	}

	public static Material itemMaterialEditorOnly {
		get {
			return Resources.Load<Material> ("ItemMaterial");
		}
	}
}
