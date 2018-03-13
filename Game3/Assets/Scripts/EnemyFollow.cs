using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;
    public float stoppingDistance;

    public Transform target;

	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
	}

    private void Update()
    {
        Vector3 myPos = transform.position;
        Vector3 targetPos = target.position;
        if (Vector2.Distance(myPos, targetPos) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(myPos, targetPos, speed * Time.deltaTime);
        }
    }
}
