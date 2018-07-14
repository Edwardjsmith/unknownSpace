using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    public enum shipType { small, med, big };

    public shipType thisShip;

    public Slider healthBar;

    public float shield;
    float health;
    float maxHealth = shipQuality * 2;
    float speed = shipQuality / 2;
    float rotationSpeed = shipQuality / 3;
    float reload = shipQuality * 100;
    float coolDown;

    public Collider2D myShield;

    public static float shipQuality;

    public GameObject ball;

    public Transform firePointLeft;
    private Transform target;

    Vector3 dir;
    Vector3 gunDir;

    public AudioSource laser;
 
    
    // Use this for initialization
    void Start()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;

        health = maxHealth;

        switch (thisShip)
        {
            case shipType.small:
            {
                shipQuality = 1;
                shield = 0;
                myShield = null;
                break;
            }
            case shipType.med:
            {
                shipQuality = 2;
                shield = health;
                break;
            }
            case shipType.big:
            {
                shipQuality = 3;
                shield = health * 2;
                break;
            }
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(myShield != null && shield <= 0)
        {
            myShield.enabled = false;
        }
        healthBar.value = calculateHealth();


        coolDown--;

        //transform.GetComponent<>
        // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (target != null)
        {
            dir = target.position - transform.position;
            dir.z = 0.0f; // Only needed if objects don't share 'z' value



            if (dir != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                        Quaternion.FromToRotation(Vector3.up, dir), rotationSpeed * Time.deltaTime);
            }


            if (Vector2.Distance(transform.position, target.position) > 10)
            {
                 transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime; //If Eneemy is a distance of 5 away, move to player
            }
          

 
            //If enemy is within a range, rotate towards and fire at the player
            if (Vector2.Distance(transform.position, target.position) <= 10 && Vector2.Distance(transform.position, target.position) > 0)
            {

                gunDir = target.position - firePointLeft.position;

                float rotationValue = (Mathf.Atan2(gunDir.y, gunDir.x) * Mathf.Rad2Deg) + 60;
                Quaternion q = Quaternion.AngleAxis(rotationValue, Vector3.forward);

                transform.rotation = Quaternion.Slerp(transform.rotation, q, rotationSpeed * Time.deltaTime);



                //Quaternion rotationValue = Quaternion.LookRotation(target.position - firePointLeft.position);
                //transform.rotation = Quaternion.Lerp(transform.rotation, rotationValue, rotationSpeed * Time.deltaTime);




                if (coolDown <= 0)
                {
                    Instantiate(ball, firePointLeft.position, transform.rotation);

                    laser.Play();

                    coolDown = reload;
                }

            }
        }
    }




    public float enemyHealth()
    {
        return health;
    }
    public float damageDone(float damage)
    {
        return health -= damage;
    }

    float calculateHealth()
    {
        return health / maxHealth;
    }
}


   
