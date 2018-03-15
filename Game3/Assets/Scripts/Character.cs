using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField] protected float movementSpeed;
    [SerializeField] protected float stoppingDistance;
    public Transform player;
    public int Health;
    public Animator myAnim { get; private set; }
    public bool isDead { get; set; }

    protected bool facingRight;

    // Use this for initialization
    public virtual void Start () {

        if (transform.rotation == Quaternion.Euler(0, 0 ,0))
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }
        myAnim = GetComponent<Animator>();
	}

    public void ChangeDirection()
    {
        if (facingRight)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
        facingRight = !facingRight;
    }
}
