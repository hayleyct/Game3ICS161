using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float speed; 

	private Vector2 direction; 
	private Rigidbody2D rb; 

	// Use this for initialization
	void Start () {
		speed = 15f;
		rb = GetComponent<Rigidbody2D> (); 
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () { 
		rb.velocity = direction * speed; 
		Destroy (gameObject, 1f);
	}

	public void Initialize(Vector2 direction) {
		this.direction = direction; 
	}	
}
