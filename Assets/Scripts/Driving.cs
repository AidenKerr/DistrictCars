using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour {

	public List<AxleInfo> axleInfos;
	public float maxTorque;
	public float maxTurn;

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

		// set motor and steering values
		float motor = Input.GetAxis("Vertical") * maxTorque;
		float steering = Input.GetAxis("Horizontal") * maxTurn;

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
	public bool motor; // are these wheels connected to motor?
	public bool steerable; // are these wheels steerable?
}
