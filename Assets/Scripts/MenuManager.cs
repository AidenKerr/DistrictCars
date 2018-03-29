using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void LevelSelect(string levelName) {
		// restart map
		switch (levelName) {
			case "restart":
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				break;
		case "nextLevel":
				SceneManager.LoadScene("level_" + (SceneManager.GetActiveScene().buildIndex));
				break;
			default:
				SceneManager.LoadScene(levelName);
				break;
		}

	}

	public void QuitGame() {
		Application.Quit();
	}
}
