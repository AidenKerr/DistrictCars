using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	public float freq;
	public float amp;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * freq) * amp * Time.deltaTime);
	}
}
