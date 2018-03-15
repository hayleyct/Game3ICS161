using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie2 : Character {
 
	//public float stoppingDistance;
	public float retreatDistance;


    private Animator anim;
    private float timeBtwShots;
	public float startTimeBtwShots;

	public GameObject projectile;

	public override void Start() {
        player = GameObject.FindGameObjectWithTag ("Player").transform;

		timeBtwShots = startTimeBtwShots;
        anim = GetComponent<Animator>();
	}

	void Update() {
		if (Vector2.Distance (transform.position, player.position) > stoppingDistance && !isDead) {
			transform.position = Vector2.MoveTowards (transform.position, player.position, movementSpeed * Time.deltaTime);
		} else if(Vector2.Distance (transform.position, player.position) < stoppingDistance && Vector2.Distance (transform.position, player.position) > retreatDistance && !isDead) {
			transform.position = this.transform.position;
		} else if(Vector2.Distance (transform.position, player.position) < retreatDistance && !isDead) {
			transform.position = Vector2.MoveTowards (transform.position, player.position, -movementSpeed * Time.deltaTime);
		}

		if (timeBtwShots <= 0) {
			Instantiate (projectile, transform.position, Quaternion.identity);
			timeBtwShots = startTimeBtwShots; 
		} else {
			timeBtwShots -= Time.deltaTime; 
		}

		
	}

	void FixedUpdate () {
        Death();
        LookAtTarget();
	}

	private void LookAtTarget()
	{
		if (player != null)
		{
			float xDir = player.transform.position.x - transform.position.x;
			if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
			{
				ChangeDirection();
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("bullet"))
		{
			Health -= 10;
		}
	}

	public void Death()
	{
		if (Health <= 0)
		{
            FindObjectOfType<SoundEffectManager>().Play("Zombie2Death");
            isDead = true;
            anim.SetBool("Death", true);
            Destroy(gameObject, 0.7f);
		}
	}
}
