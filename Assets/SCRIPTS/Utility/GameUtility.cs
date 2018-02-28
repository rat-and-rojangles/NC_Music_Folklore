using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Static methods useful to the game.
/// </summary>
public static class GameUtility {
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
}
