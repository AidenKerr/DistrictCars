using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLimiter : MonoBehaviour {

	public int fps;

	void Awake () {
		QualitySettings.vSyncCount = 0;  // VSync must be disabled
		Application.targetFrameRate = fps;
	}

}
