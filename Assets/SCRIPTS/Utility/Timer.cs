using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Timer that runs for a fixed amount of time.
/// </summary>
public class Timer {
	private float duration;
	private float elapsedTime;
	private bool m_complete;
	/// <summary>
	/// Is this timer done ticking?
	/// </summary>
	public bool complete {
		get { return m_complete; }
	}
	public float ratio {
		get {
			if (duration == 0f) {
				return 1f;
			}
			else {
				return Mathf.Clamp01 (elapsedTime / duration);
			}
		}
	}
	public Timer (float duration) {
		this.duration = duration;
		m_complete = false;
		elapsedTime = 0f;
	}

	/// <summary>
	/// Begin the timer.
	/// </summary>
	public IEnumerator StartTicking () {
		while (elapsedTime < duration) {
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		m_complete = true;
	}
}
