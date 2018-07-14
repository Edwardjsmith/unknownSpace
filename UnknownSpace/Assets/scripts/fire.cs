using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class fire : MonoBehaviour
{

    public GameObject explosion;
    public GameObject lootSloop;
    public GameObject lootMed;
    public GameObject lootBig;
    public Transform firePointLeft;
    public Transform firePointRight;
    public GameObject hit;

    public AudioSource boom;


    public float speed = 150;
    
    
    // Use this for initialization
    void Start ()
    {
        /*if (Input.GetKeyDown(KeyCode.X))
        {
            speed = -speed; //If input is left, speed will be inverse
        }*/
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddRelativeForce(Vector2.right * speed);

        
    }

    

    // Update is called once per frame
    void Update ()
    {


        

        // rigid.velocity = speed;


        Destroy(gameObject,4.0f); //Destroy after 4 secs
        

    }
    //Destroys ships based on health and creates loot based on ship
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            boom.Play();
        }


        if (other.tag == "EnemySmall")
        {
            other.GetComponent<EnemyScript>().damageDone(playerAttributes.instance.damageUpgradeLevel);
            Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.GetComponent<EnemyScript>().enemyHealth() <= 0)
            {
                Destroy(other.gameObject);
                Instantiate(explosion, other.transform.position, other.transform.rotation);
               
                Instantiate(lootSloop, other.transform.position, other.transform.rotation);
                
                winOrLose.numberOfEnemies--;
            }
        }
        if (other.tag == "EnemyMed")
        {
            if (other.GetComponent<EnemyScript>().shield > 0)
            {
                other.GetComponent<EnemyScript>().shield -= playerAttributes.instance.damageUpgradeLevel;
            }
            else
            {

                other.GetComponent<EnemyScript>().damageDone(playerAttributes.instance.damageUpgradeLevel);
              
                if (other.GetComponent<EnemyScript>().enemyHealth() <= 0)
                {
                    Destroy(other.gameObject);
                    Instantiate(explosion, other.transform.position, other.transform.rotation);
                    Instantiate(lootMed, other.transform.position, other.transform.rotation);

                    winOrLose.numberOfEnemies -= 2;
                }
            }

            Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "EnemyBig")
        {
            if (other.GetComponent<EnemyScript>().shield > 0)
            {
                other.GetComponent<EnemyScript>().shield -= playerAttributes.instance.damageUpgradeLevel;
            }
            else 
            {
                other.GetComponent<EnemyScript>().damageDone(playerAttributes.instance.damageUpgradeLevel);

                if (other.GetComponent<EnemyScript>().enemyHealth() <= 0)
                {
                    Destroy(other.gameObject);
                    Instantiate(explosion, other.transform.position, other.transform.rotation);


                    Instantiate(lootBig, other.transform.position, other.transform.rotation);

                    winOrLose.numberOfEnemies -= 3;
                }
            }
            Instantiate(hit, transform.position, transform.rotation);

            Destroy(gameObject);
        }

       


    }
}
