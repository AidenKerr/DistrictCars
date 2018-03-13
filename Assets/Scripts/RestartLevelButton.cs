using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartLevelButton : MonoBehaviour {

	public Button button;

	// Use this for initialization
	void Start () {
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(RestartLevel);
	}

	void RestartLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
