using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class enemyFire : MonoBehaviour
{
    float damage = EnemyScript.shipQuality; //Damage is based on the quality of the ship that fires the shot
    float speed = 8 / EnemyScript.shipQuality; //by 
    public GameObject hit;
    public AudioSource boom;
    // Use this for initialization
    void Start ()
    {

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();


        rigid.velocity = transform.up * speed;


        Destroy(gameObject, 6.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {

        /*Rigidbody2D rigid = GetComponent<Rigidbody2D>();


        rigid.velocity = transform.right * speed;


        Destroy(gameObject, 2.0f);*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "playerShip")
        {
            playerAttributes.instance.playerHealth -= damage;
            
            
        }

        if (other.name == "playerSail")
        {
            playerAttributes.instance.sailHealth--;
        }
        Instantiate(hit, transform.position, transform.rotation);
        hit.transform.parent = other.gameObject.transform;
        
        boom.Play();
        Destroy(gameObject);


    }

}
