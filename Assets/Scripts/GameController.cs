using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text winText;
	public Text countText;
	public Canvas EscapeCanvas;

	private int coins;
	private int count;
	private bool open; // is the escape menu open?

	// Use this for initialization
	void Start () {
		// set up coin counter
		coins = GameObject.FindGameObjectsWithTag("Coin").Length;
		countText.text = count.ToString() + "/" + coins.ToString();

		open = false;
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
			EscapeCanvas.gameObject.SetActive(true);
			open = true;
		}
	}

	// set the text of the coin counter
	void SetCountText() {
		countText.text = count.ToString() + "/" + coins.ToString();
		if (count >= coins) {
			GameOver(true);
		}
	}

	public void Update() {
		if (Input.GetButtonDown("Cancel")) {
			if (open) {
				EscapeCanvas.gameObject.SetActive(false);
				open = false;
			} else {
				EscapeCanvas.gameObject.SetActive(true);
				open = true;
			}
		}
	}
}
