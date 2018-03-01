using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject {

	private CollectibleObjectSerialization m_serialization;

	public CollectibleObjectSerialization ExposeSerializationDebug {
		get { return m_serialization; }
	}

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
		if (object.ReferenceEquals (a, null)) {         // a is null
			return object.ReferenceEquals (b, null);
		}
		else {                                          // a is not null
			if (object.ReferenceEquals (b, null)) {
				return false;
			}
			return a.m_serialization == b.m_serialization;
		}
	}
	public static bool operator != (CollectibleObject a, CollectibleObject b) {
		if (object.ReferenceEquals (a, null)) {         // a is null
			return !object.ReferenceEquals (b, null);
		}
		else {                                          // a is not null
			if (object.ReferenceEquals (b, null)) {
				return true;
			}
			return a.m_serialization != b.m_serialization;
		}
	}
}
