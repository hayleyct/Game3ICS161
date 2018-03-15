using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1 : Character
{
    // Use this for initialization
    public override void Start () {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

    private void Update()
    {
        LookAtTarget();
        FollowEnemy();
        Death();

    }

    private void LookAtTarget()
    {
        if (player != null)
        {
            float xDir = player.transform.position.x - transform.position.x;
            if ((xDir < 0 && facingRight || xDir > 0 && !facingRight) && !isDead)
            {
                ChangeDirection();
            }
        }
    }

    private void FollowEnemy()
    {
        Vector3 myPos = transform.position;
        Vector3 targetPos = player.position;
        if ((Vector2.Distance(myPos, targetPos) > stoppingDistance) && !isDead)
        {
            transform.position = Vector2.MoveTowards(myPos, targetPos, movementSpeed * Time.deltaTime);
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
            FindObjectOfType<SoundEffectManager>().Play("Zombie1Death");
            isDead = true;
            myAnim.SetBool("Death", true);
            Destroy(gameObject, 0.7f);
        }
    }
}
