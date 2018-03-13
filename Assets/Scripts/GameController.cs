using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text winText;
	public Text countText;
	public Button restartButton;

	private int coins;
	private int count;

	// Use this for initialization
	void Start () {
		// restart button should not be visible
		restartButton.gameObject.SetActive(false);

		// set up coin counter
		coins = GameObject.FindGameObjectsWithTag("Coin").Length;
		countText.text = count.ToString() + "/" + coins.ToString();
	}
		
	void OnTriggerEnter(Collider other) {
		// when you collide with coin, hide coin, increase counter.
		switch (other.gameObject.tag) {
			case "Coin":
				other.gameObject.SetActive(false);
				count++;
				SetCountText();
				break;
			case "Ground":
				GameOver(false);
				break;
		}
	}

	void GameOver (bool win) {
		if (win) {
			winText.text = "You Win!";
		} else {
			restartButton.gameObject.SetActive(true);
		}
	}

	// set the text of the coin counter
	void SetCountText() {
		countText.text = count.ToString() + "/" + coins.ToString();
		if (count >= coins) {
			GameOver(true);
		}
	}
}
