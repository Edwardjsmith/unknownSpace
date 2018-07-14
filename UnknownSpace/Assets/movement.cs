using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject hit;
    public float asteroidDamage;
    public AudioSource boom;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-500, 500), Random.Range(-500, 500)));

        Destroy(gameObject, 20.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            playerAttributes.instance.playerHealth -= 3;
            Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "EnemyBig")
        {
            if (other.GetComponent<EnemyScript>().shield > 0)
            {
                other.GetComponent<EnemyScript>().damageDone(0);
            }
            else
            {
                other.GetComponent<EnemyScript>().damageDone(asteroidDamage);
                boom.Play();
            }

            Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        if (other.tag == "EnemyMed")
        {
            if (other.GetComponent<EnemyScript>().shield > 0)
            {
                other.GetComponent<EnemyScript>().shield -= asteroidDamage;
            }
            else
            {
                other.GetComponent<EnemyScript>().damageDone(asteroidDamage);
                boom.Play();
            }

            
            Instantiate(hit, transform.position, transform.rotation);
            
            Destroy(gameObject);
        }
        if (other.tag == "EnemySmall")
        {
            other.GetComponent<EnemyScript>().damageDone(asteroidDamage);
            Instantiate(hit, transform.position, transform.rotation);
            boom.Play();
            Destroy(gameObject);
        }

        if (other != null)
        {
            boom.Play();
        }
    }
}
       
