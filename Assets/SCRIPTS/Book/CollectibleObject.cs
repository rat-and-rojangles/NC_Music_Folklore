using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject {

	private CollectibleObjectSerialization m_serialization;

	public bool discovered;

	public CollectibleObject (CollectibleObjectSerialization collectibleObjectSerialization) {
		m_serialization = collectibleObjectSerialization;
		discovered = false;
	}

	public string title {
		get { return m_serialization.title; }
	}

	public string text {
		get { return m_serialization.text; }
	}

	public Sprite icon {
		get { return m_serialization.icon; }
	}

	public Sprite iconBlurred {
		get { return m_serialization.iconBlurred; }
	}

	public override bool Equals (object other) {
		return (other is CollectibleObject) && (m_serialization == ((CollectibleObject)other).m_serialization);
	}
	public override int GetHashCode () {
		return m_serialization.GetHashCode ();
	}

	public static bool operator == (CollectibleObject a, CollectibleObject b) {
		return (object.ReferenceEquals (a, null) && object.ReferenceEquals (b, null)) || (a.m_serialization == b.m_serialization);
	}
	public static bool operator != (CollectibleObject a, CollectibleObject b) {
		return (!object.ReferenceEquals (a, null) && object.ReferenceEquals (b, null)) || (object.ReferenceEquals (a, null) && !object.ReferenceEquals (b, null)) || (a.m_serialization == b.m_serialization);
	}
}
