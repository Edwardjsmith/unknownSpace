using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToPlayer : MonoBehaviour
{
    private float speed = 2;
    private Transform target;
    // Use this for initialization
    void Start ()

    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector2.Distance(transform.position, target.position) <= 2)
        {
            transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
        }

    }
}
