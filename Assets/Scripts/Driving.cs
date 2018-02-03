﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour {

	public Rigidbody rb; // rigidbody for velocity purposes
	public List<AxleInfo> axleInfos;
	public float maxTorque;
	public float maxTurn;
	public float maxWheelTurnVelocity; // velocity at which wheel turning becomes minimal;

	private float velocityBase;

	void Start() {
		rb = GetComponent<Rigidbody>();
		velocityBase = Mathf.Pow(10, Mathf.Log10(maxTurn) / maxWheelTurnVelocity);
	}

	public void ApplyVisuals(WheelCollider collider) {
		if (collider.transform.childCount == 0) {
			return;
		}

		Transform visualWheel = collider.transform.GetChild(0);

		Vector3 position;
		Quaternion rotation;
		collider.GetWorldPose(out position, out rotation);
	
		visualWheel.transform.position = position;
		visualWheel.transform.rotation = rotation;

	}

	void FixedUpdate() {

		float speed = rb.velocity.magnitude;
		print("velocity = " + speed);

		// set motor and steering values
		float motor = Input.GetAxis("Vertical") * maxTorque;
		// Apply the exponentially decreasing turning angle
		// The ternary operator is to limit it at 90% of it's decrease so it never reaches 0 turning angle
		float a = (speed > 0.9f * maxWheelTurnVelocity) ? maxTurn - Mathf.Pow(velocityBase, 0.9f * maxWheelTurnVelocity) : maxTurn - Mathf.Pow(velocityBase, speed);
		float steering = Input.GetAxis("Horizontal") * a;

		// apply motor and steering values when needed
		foreach (AxleInfo axleInfo in axleInfos) {

			if (axleInfo.motor) {
				axleInfo.leftWheel.motorTorque = motor;
				axleInfo.rightWheel.motorTorque = motor;
			}
			if (axleInfo.steerable) {
				axleInfo.leftWheel.steerAngle = steering;
				axleInfo.rightWheel.steerAngle = steering;
			}
			ApplyVisuals(axleInfo.leftWheel);
			ApplyVisuals(axleInfo.rightWheel);
		}

	}
}

[System.Serializable]
public class AxleInfo {
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public bool motor; // are these wheels connected to the motor?
	public bool steerable; // are these wheels steerable?
}