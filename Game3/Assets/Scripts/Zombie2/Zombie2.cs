using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie2 : MonoBehaviour {

	public float speed; 
	public float stoppingDistance;
	public float retreatDistance;
	[SerializeField] public float health; 

	private float timeBtwShots;
	public float startTimeBtwShots;

	public GameObject projectile;
	private Transform player;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		timeBtwShots = startTimeBtwShots;

		health = 70;
	}

	void Update() {
		if (Vector2.Distance (transform.position, player.position) > stoppingDistance) {
			transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
		} else if(Vector2.Distance (transform.position, player.position) < stoppingDistance && Vector2.Distance (transform.position, player.position) > retreatDistance) {
			transform.position = this.transform.position;
		} else if(Vector2.Distance (transform.position, player.position) < retreatDistance) {
			transform.position = Vector2.MoveTowards (transform.position, player.position, -speed * Time.deltaTime);
		}

		if (timeBtwShots <= 0) {
			Instantiate (projectile, transform.position, Quaternion.identity);
			timeBtwShots = startTimeBtwShots; 
		} else {
			timeBtwShots -= Time.deltaTime; 
		}

		Death ();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("bullet"))
		{
			health -= 10;
		}
	}

	public void Death()
	{
		if (health <= 0)
		{
			Destroy(gameObject, 0.1f);
		}
	}

//	private IZombie2State currentState;
//	[SerializeField] EnemyFollow enemyFollow;
//	private Transform target;
//
//	// Use this for initialization
//	public override void Start () {
//		base.Start();
//		Health = 70;
//	}
//
//	private void Update()
//	{
//		Death();
//	}
//
//	void FixedUpdate () {
//		LookAtTarget();
//	}
//
//	private void LookAtTarget()
//	{
//		if (target != null)
//		{
//			float xDir = target.transform.position.x - transform.position.x;
//			if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
//			{
//				ChangeDirection();
//			}
//		}
//		else
//		{
//			target = enemyFollow.target;
//		}
//	}
//
//	private void OnCollisionEnter2D(Collision2D collision)
//	{
//		if (collision.gameObject.CompareTag("bullet"))
//		{
//			Health -= 10;
//		}
//	}
//
//	public new void Attack()
//	{
//		myAnim.SetBool("Attack", true);
//	}
//
//	public void Death()
//	{
//		if (Health <= 0)
//		{
//			Destroy(gameObject, 0.1f);
//		}
//	}
}
