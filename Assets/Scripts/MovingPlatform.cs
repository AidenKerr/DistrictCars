using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	private float nextTime = 0.0f;
	private float period = 4.9f;

	public Transform platform;

	// Update is called once per frame
	void Update () {
		platform.transform.Translate(0, 0, -1);
		if (Time.time > nextTime) {
			nextTime += period;
			platform.transform.position = new Vector3(0, -25, 65);
		}
	}
}
