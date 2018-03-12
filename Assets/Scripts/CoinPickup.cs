using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour {

	public Text winText;
	public Text countText;

	private int coins;
	private int count;

	// Use this for initialization
	void Start () {
		coins = GameObject.FindGameObjectsWithTag("Coin").Length;
		countText.text = count.ToString() + "/" + coins.ToString();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Coin")) {
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}

	void SetCountText() {
		countText.text = count.ToString() + "/" + coins.ToString();
		if (count >= coins) {
			winText.text = "You Win!";
		}
	}
}
