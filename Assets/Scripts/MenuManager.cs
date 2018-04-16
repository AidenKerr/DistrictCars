using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public bool restartable;

	public void LevelSelect(string levelName) {
		// restart map
		switch (levelName) {
			case "restart":
				Restart();
				break;
		case "nextLevel":
				SceneManager.LoadScene("level_" + (SceneManager.GetActiveScene().buildIndex));
				break;
			default:
				SceneManager.LoadScene(levelName);
				break;
		}

	}


	// not a menu but I put it here because it's still technically UI
	void Update() {
		if (Input.GetButtonDown("restart")) {
			Restart();
		}
	}

	public void Restart() {
		if (restartable && Time.timeSinceLevelLoad > 1) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void QuitGame() {
		Application.Quit();
	}
}
