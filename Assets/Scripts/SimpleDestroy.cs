using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDestroy : MonoBehaviour {

	public GameObject debrisPrefab;
	public float velocityMag = 17f;

	void OnCollisionEnter(Collision collision) {
		if (collision.relativeVelocity.magnitude > velocityMag) {
			gameObject.SetActive(false);
			Instantiate(debrisPrefab, transform.position, transform.rotation);
		}
	}
}
