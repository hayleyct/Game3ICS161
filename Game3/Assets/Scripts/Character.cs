using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField] protected float movementSpeed;
    public bool facingRight;
    public int Health;

    public bool Attack { get; set; }
    public Animator myAnim { get; private set; }

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
	
	// Update is called once per frame
	void Update () {
		
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
