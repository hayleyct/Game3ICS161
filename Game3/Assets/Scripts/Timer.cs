using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public float timeLeft = 60;
	public Text timerText;
    [SerializeField] Player player;

	private int level; 

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
		level = 1; 
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timerText.text = "TIME LEFT: " + timeLeft.ToString ("f2");
		if (timeLeft < 0) {
			if (player.playerHealth > 0) {
				timerText.text = "PLAYER 1 WINS";
                Time.timeScale = 0f;
				loadNextLevel ();
            }
		}
        if (player.playerHealth <= 0)
        {
            timerText.text = "PLAYER 2 WINS";
            Time.timeScale = 0f;
			loadNextLevel ();
        }
	}

	void loadNextLevel() {
		level = SceneManager.GetActiveScene ().buildIndex; 
		SceneManager.LoadScene (level + 1);
	}
}
