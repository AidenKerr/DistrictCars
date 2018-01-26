using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour {

	public WheelCollider wc;
	public bool steerable;
	public float maxTorque;
	public float maxTurn;

	void Start () {
		
	}

	void FixedUpdate () {

		wc.motorTorque = Input.GetAxis("Vertical") * maxTorque;
	
		if (steerable) {
			wc.steerAngle = Input.GetAxis("Horizontal") * maxTurn;
		}

	}
}
