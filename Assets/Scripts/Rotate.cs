using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float rate;
	public Vector3 axis;

	void Update() {
		transform.Rotate(axis * Time.deltaTime * rate);
	}
}
