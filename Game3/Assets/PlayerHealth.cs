using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public int playerHealth = 100;

    private GameObject [] hearts;

    // private static Sprite heartFull;
    private static Sprite heartHalf;
    private static Sprite heartEmpty;

    void Awake() {
    	// heartFull = Resources.Load("rock", typeof(Sprite)) as Sprite;
        heartHalf = Resources.Load("heart-half", typeof(Sprite)) as Sprite;
        heartEmpty = Resources.Load("heart-empty", typeof(Sprite)) as Sprite;
    }

    void Start () {
		hearts = new GameObject[10];
		for (int i = 0; i < 10; i++) {
			hearts[i] = transform.Find("PlayerHealth " + (i + 1)).gameObject;
		}

		// transform.Find("PlayerHealth 1").gameObject.GetComponent<SpriteRenderer>().sprite = heartEmpty;
		// hearts[0].GetComponent<SpriteRenderer>().sprite = heartEmpty;

	}

	// Update is called once per frame
	void Update () {
	}

	public void subtractPlayerHealth(int hitValue) {
		if (hitValue == 10) {
			// Half a heart
			if (playerHealth % 10 == 5) {
				int heart1 = playerHealth / 10;
				hearts[heart1].GetComponent<SpriteRenderer>().sprite = heartEmpty;

				if (playerHealth > 5) {
					int heart2 = playerHealth / 10 - 1;
					hearts[heart2].GetComponent<SpriteRenderer>().sprite = heartHalf;
				}
			} else {
				int heart = playerHealth / 10 - 1;
				hearts[heart].GetComponent<SpriteRenderer>().sprite = heartEmpty;
			}
		} else {
			// Half a heart
			if (playerHealth % 10 == 5) {
				int heart = playerHealth / 10;
				hearts[heart].GetComponent<SpriteRenderer>().sprite = heartEmpty;
			} else {
				int heart = playerHealth / 10 - 1;
				hearts[heart].GetComponent<SpriteRenderer>().sprite = heartHalf;
			}
		}

		playerHealth -= hitValue;
	}
}
