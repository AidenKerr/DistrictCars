using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour {

	public Rigidbody rb; // rigidbody for velocity purposes
	public List<AxleInfo> axleInfos;
	public float maxTorque;
	public float maxBrakeTorque;
	public float maxTurn;
	public float maxWheelTurnVelocity; // velocity at which wheel turning becomes minimal;
	public bool canBrake;
	public AudioSource sound;
	public float maxPitch;

	private float velocityBase;

	void Start() {
		rb = GetComponent<Rigidbody>();
		velocityBase = Mathf.Pow(10, Mathf.Log10(maxTurn) / maxWheelTurnVelocity);
		sound = GetComponent<AudioSource>();
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
		float AxisVert = Input.GetAxis("Vertical");
		float brake = Input.GetAxis("Brake");

		// set motor and steering values
		float motor = 0;
		float dotProd = Vector3.Dot(rb.velocity, rb.transform.forward); // for the sole purpose of acquiring a pos/neg value of velocity in a non-Vector3 type
		// if desired direction is opposite moving direction
		if (Mathf.Sign(AxisVert) != Mathf.Sign(dotProd)) {
			brake = 1;
		} else {
			motor = AxisVert * maxTorque;
		}


		// set motor sound pitch
		float inc = 0.01f;
		if (AxisVert != 0 && sound.pitch < maxPitch) {
			sound.pitch += inc;
		} else if (sound.pitch != 1) {
			sound.pitch -= inc;
		}

		// Apply the exponentially decreasing turning angle
		// The ternary operator is to limit it at x% of it's decrease so it never reaches 0 turning angle
		float angleCutoff = 0.98f;
		float a = (speed > angleCutoff * maxWheelTurnVelocity) ? maxTurn - Mathf.Pow(velocityBase, angleCutoff * maxWheelTurnVelocity) : maxTurn - Mathf.Pow(velocityBase, speed);
		float steering = Input.GetAxis("Horizontal") * a;

		// apply motor and steering values when needed
		foreach (AxleInfo axleInfo in axleInfos) {

			if (brake > 0 && canBrake) {
				axleInfo.leftWheel.brakeTorque = maxBrakeTorque;
				axleInfo.rightWheel.brakeTorque = maxBrakeTorque;
			} else {
				axleInfo.leftWheel.brakeTorque = 0;
				axleInfo.rightWheel.brakeTorque = 0;
			}
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
