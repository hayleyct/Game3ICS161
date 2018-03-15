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
	public int invulnerableCooldown;

	private GameObject sprite;
    public int level;

    private float timer;
    private float flashCooldown;
    private float invulnerableEnd;

    private bool isInvulnerable;
    private bool isSpriteShowing;

    void Start () {
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			score = 0;
			level = 1;
		}
		sprite = transform.Find("Sprite").gameObject;
		timer = 0;
		flashCooldown = 0;
		invulnerableEnd = 0;
		isInvulnerable = false;
		isSpriteShowing = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.V)) {
			Shoot ();
		}

		if (isInvulnerable) {
			if (timer >= flashCooldown) {
				flashCooldown = timer + 0.1f;
				isSpriteShowing = !isSpriteShowing;
				sprite.GetComponent<Renderer>().enabled = isSpriteShowing;
			}

			if (timer > invulnerableEnd) {
				isInvulnerable = false;
				isSpriteShowing = true;
				sprite.GetComponent<Renderer>().enabled = true;
			}
		}

		timer += Time.deltaTime;
	}

	void hurtPlayer(int dmg) {
		if (!isInvulnerable) {
			FindObjectOfType<SoundEffectManager>().Play ("PlayerDmg");
			transform.parent.gameObject.GetComponent<PlayerHealth>().subtractPlayerHealth(dmg);

			isInvulnerable = true;
			flashCooldown = timer;
			invulnerableEnd = timer + invulnerableCooldown;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Zombie")) {
			hurtPlayer(10);
			// setHealthText ();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("ZombBullet")) {
			hurtPlayer(5);
			// setHealthText ();
		}
	}

	void Shoot() {
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

	public void saveLevel() {
		PlayerPrefs.SetInt ("Level", level);
	}

	public int getSavedLevel() {
		int tempLevel = PlayerPrefs.GetInt ("Level");
		return tempLevel;
	}
}
