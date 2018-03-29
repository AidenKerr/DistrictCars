using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Canvas winScreen;
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

		winScreen.gameObject.SetActive(false);
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

	// arg "win" true  -> win
	// arg "win" false -> lose
	void GameOver (bool win) {
		if (win) {
			EscapeCanvas.gameObject.SetActive(false);
			winScreen.gameObject.SetActive(true);
		} else if(!winScreen.gameObject.activeSelf) {
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
			} else if (!winScreen.gameObject.activeSelf) {
				EscapeCanvas.gameObject.SetActive(true);
				open = true;
			}
		}
	}
}
