using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void LevelSelect(string levelName) {
		// restart map
		if (levelName == "restart") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		} else {
			SceneManager.LoadScene(levelName);
		}

	}

	public void QuitGame() {
		Application.Quit();
	}
}
