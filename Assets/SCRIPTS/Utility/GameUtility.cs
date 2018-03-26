using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Static methods useful to the game.
/// </summary>
public static class GameUtility {

	private static GameObject m_mapObjectTemplate = null;
	public static GameObject mapObjectTemplate {
		get {
			if (m_mapObjectTemplate == null) {
				m_mapObjectTemplate = Resources.Load<GameObject> ("MapObjectTemplate");
			}
			return m_mapObjectTemplate;
		}
	}

	private static SequencerClip[] m_allSequencerClips = null;
	/// <summary>
	/// All sequencer clips in the resources folder, sorted by length then name.
	/// </summary>
	/// <returns></returns>
	public static SequencerClip[] allSequencerClips {
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
	public static CollectibleObject[] GetAllCollectibleObjects (int numberDiscovered) {
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
}
