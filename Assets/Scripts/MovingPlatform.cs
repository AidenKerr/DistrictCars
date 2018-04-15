using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float speed = 90f;

	private float nextTime = 0.0f;
	private float period = 4.9f;

	public Transform platform;

	void FixedUpdate () {
		platform.transform.Translate(Vector3.back * Time.deltaTime * speed);
		if (Time.timeSinceLevelLoad > nextTime) {
			nextTime += period;
			platform.transform.position = new Vector3(0, -25, 65);
		}
	}
}
