using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuManager : MonoBehaviour {

	public GameObject controlMenuUI;

	public void startGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);  
	}

	public void quitGame() {
		Application.Quit ();
	}

	public void Controls() {
		controlMenuUI.SetActive (true);
		Time.timeScale = 0f; 
	}

	public void Back() {
		controlMenuUI.SetActive (false);
	}
}

