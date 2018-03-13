using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1 : Character
{

    private IZombie1State currentState;
    [SerializeField] EnemyFollow enemyFollow;
    private Transform target;

	// Use this for initialization
	public override void Start () {
        base.Start();
        Health = 50;
	}

    private void Update()
    {
        Death();
    }

    void FixedUpdate () {
        LookAtTarget();
	}

    private void LookAtTarget()
    {
        if (target != null)
        {
            float xDir = target.transform.position.x - transform.position.x;
            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
        else
        {
            target = enemyFollow.target;
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Attack();
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Health -= 10;
        }
    }

    public new void Attack()
    {
        myAnim.SetBool("Attack", true);
    }

    public void Death()
    {
        if (Health <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
