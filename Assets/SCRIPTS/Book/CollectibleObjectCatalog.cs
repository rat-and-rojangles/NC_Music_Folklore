using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObjectCatalog : ScriptableObject {

	[SerializeField]
	private CollectibleObjectSerialization m_blankPage;
	public CollectibleObjectSerialization blankPage {
		get { return m_blankPage; }
	}

	[SerializeField]
	private CollectibleObjectSerialization [] allCollectibleObjects;

	/// <summary>
	/// Return all collectible objects. 
	/// </summary>
	public CollectibleObject [] GetAllCollectibleObjects (int numberDiscovered) {
		CollectibleObject [] tempCollectibles = new CollectibleObject [allCollectibleObjects.Length];
		for (int x = 0; x < tempCollectibles.Length; x++) {
			tempCollectibles [x] = new CollectibleObject (allCollectibleObjects [x]);
			tempCollectibles [x].discovered = x < numberDiscovered;
		}
		return tempCollectibles;
	}
}
