using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public PlatformerCharacter2D pltfmChr2D;
	public int score;
    public Text scoreText;
	public Text playerHealthText;
	public GameObject bulletPrefab;
	public GameObject bulletSpawn;

    private int level;

    void Start () {
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			score = 0;
			level = 1;
			setCountText ();
			setHealthText ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.V)) {
			Shoot ();
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Zombie")) {
			FindObjectOfType<SoundEffectManager>().Play ("PlayerDmg");
			transform.parent.gameObject.GetComponent<PlayerHealth>().subtractPlayerHealth(10);
			// setHealthText ();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("ZombBullet")) {
			FindObjectOfType<SoundEffectManager>().Play ("PlayerDmg");
			transform.parent.gameObject.GetComponent<PlayerHealth>().subtractPlayerHealth(5);
			// setHealthText ();
		}
	}

	public void setCountText() {
		scoreText.text = "Score: " + score.ToString ();
	}

	public void setHealthText() {
		// playerHealthText.text = "Health: " + playerHealth.ToString ();
		// if (playerHealth < 0) {
			//SceneManager.LoadScene ("GameOver");
		// }
	}

	void Shoot() {
		//		GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
		//		bullet.transform.position = bulletSpawn.transform.position;
		if (pltfmChr2D.m_FacingRight) {
			GameObject bullet = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);
			bullet.transform.position = bulletSpawn.transform.position;
			bullet.GetComponent<Bullet> ().Initialize (Vector2.right);
		} else {
			GameObject bullet = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);
			bullet.transform.position = bulletSpawn.transform.position;
			bullet.GetComponent<Bullet> ().Initialize (Vector2.left);
		}
	}
}
