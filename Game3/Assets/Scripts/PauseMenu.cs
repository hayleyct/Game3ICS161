using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject controlMenuUI;

	void Start(){
		Time.timeScale = 1f; 
	}

	void Update () {

	}

	public void Resume() {
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause() {
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void LoadMenu() {
		SceneManager.LoadScene ("StartMenu");
	}

	public void RestartLevel() {
		Scene curLevel = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (curLevel.name);
	}

	public void Controls() {
		pauseMenuUI.SetActive (false);
		controlMenuUI.SetActive (true);
	}

	public void Back() {
		pauseMenuUI.SetActive (true);
		controlMenuUI.SetActive (false);
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
