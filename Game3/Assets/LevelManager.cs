using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private int level; 

	public void LoadNextLevel() {
		level = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (level + 1);
	}

	public void LoadMenu() {
		SceneManager.LoadScene ("StartMenu");
	}
}
