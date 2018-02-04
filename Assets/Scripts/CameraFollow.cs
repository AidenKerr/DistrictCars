using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target; // target object
	public float smoothSpeed = 0.125f; // speed of smooth
	private Vector3 velocity = Vector3.zero; // velocity variable used for SmoothDamp

	void FixedUpdate() {

		Vector3 desiredPos = target.position; // desired position is the objects location
		Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothSpeed); // "blend" the two locations
		transform.position = smoothedPos; // set the camera to the smoothed location

		transform.LookAt(target.parent); // set the camera to always look at the object
	}

}
