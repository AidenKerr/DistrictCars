using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target; // target object
	public float smoothSpeed = 0.125f; // speed of smooth
	private Vector3 offset;
	public float offsetZ = -5f;
	public float offsetY = 1.5f;
	private Vector3 velocity = Vector3.zero; // velocity variable used for SmoothDamp

	void FixedUpdate() {

		// Set the offset, off the setoff
		// The target.transform.forward allows the offset to always be relative to the car.
		offset = target.transform.forward;
		offset *= offsetZ;
		offset.y += offsetY;

		Vector3 desiredPos = target.position + offset; // desired position is the objects location
		Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothSpeed); // "blend" the two locations
		transform.position = smoothedPos; // set the camera to the smoothed location

		transform.LookAt(target); // set the camera to always look at the object
	}

}
