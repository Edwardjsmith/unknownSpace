
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    public static Player instance = null;


    float speed;
    float maxSpeed;
    float turnSpeed;
    float reload;

    //public AudioClip audio;
    //public AudioSource source;

    public Button leftMove;
    public Button rigthMove;

    public AudioSource laser;

    public GameObject shipDir;
    public GameObject returnToManagement;
    public GameObject canvas;

    public Slider healthBar;
    public Slider sailhealth;


    private Rigidbody2D rigid;

    public Transform firePointL;
    public Transform firePointR;

    public GameObject cannonBall;

    float coolDownLeft;
    float coolDownRight;

    bool left = false;
    bool right = false;
    //Makes player a singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        if (playerAttributes.instance != null) //Sets player attributes
        {
            speed = playerAttributes.instance.playerSpeed;
            //maxSpeed = playerAttributes.instance.playerMaxSpeed;
            turnSpeed = playerAttributes.instance.playerTurnSpeed;
            reload = playerAttributes.instance.reloadSpeed;

          //  source.clip = audio;

            
        }


    }

    //Instantiates cannonballs to fire right and set right reload
    public void fireLeft() 
    {
        if (coolDownLeft <= 0)
        {
            GameObject cannonBall1 = Instantiate(cannonBall, firePointL.position, transform.rotation);
            GameObject cannonball2 = Instantiate(cannonBall, firePointL.position, transform.rotation * Quaternion.Euler(0, 0, 45));
            GameObject cannonBall2 = Instantiate(cannonBall, firePointL.position, transform.rotation * Quaternion.Euler(0, 0, -45));
            cannonBall1.GetComponent<fire>().speed = -cannonBall1.GetComponent<fire>().speed;
            cannonball2.GetComponent<fire>().speed = -cannonball2.GetComponent<fire>().speed;
            cannonBall2.GetComponent<fire>().speed = -cannonBall2.GetComponent<fire>().speed;

            laser.Play();

            coolDownLeft = reload;
        }
    }

    //.Same as above but for left
    public void fireRight()
    {
        if (coolDownRight <= 0)
        {
            GameObject cannonBall1 = Instantiate(cannonBall, firePointR.position, transform.rotation);
            GameObject cannonBall2 = Instantiate(cannonBall, firePointR.position, transform.rotation * Quaternion.Euler(0, 0, 45));
            GameObject cannonBall3 = Instantiate(cannonBall, firePointR.position, transform.rotation * Quaternion.Euler(0, 0, -45));
            cannonBall1.GetComponent<fire>().speed = cannonBall1.GetComponent<fire>().speed;
            cannonBall2.GetComponent<fire>().speed = cannonBall2.GetComponent<fire>().speed;
            cannonBall3.GetComponent<fire>().speed = cannonBall3.GetComponent<fire>().speed;

            laser.Play();

            coolDownRight = reload;
        }
    }

    //turns ship right
    public void turnRight()
    {
        
        rigid.MoveRotation(rigid.rotation - turnSpeed * Time.deltaTime);
     
    }


    public void OnPointerDownRight()
    {
        right = true;
    }
    public void OnPointerUpRight()
    {
        right = false;
    }

    //turns ship left
    public void turnLeft()
    {
       
        rigid.MoveRotation(rigid.rotation + turnSpeed * Time.deltaTime);
        
    }
    public void OnPointerDownLeft()
    {
        left = true;
    }
    public void OnPointerUpLeft()
    {
        left = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerAttributes.instance != null)
        {
       
            healthBar.value = calculateHealth();
            sailhealth.value = calculateSailHealth();

            coolDownLeft--;
            coolDownRight--;
            
            var heading = shipDir.transform.position - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;

            rigid.AddForce(direction * speed);

            Vector2 vel = rigid.velocity;

            vel.x = Mathf.Clamp(vel.x, 0, maxSpeed);
            vel.y = Mathf.Clamp(0, vel.y, maxSpeed);

            if (right == true)
            {
                turnRight();
            }
            if (left == true)
            {
                turnLeft();
            }



            /*
            if (!Input.GetKeyDown(KeyCode.C))
            {
                if (Input.GetKeyDown(KeyCode.X) && coolDownLeft <= 0)
                {
                    Instantiate(cannonBall, firePointL.position, transform.rotation);
                    Instantiate(cannonBall, firePointL.position, transform.rotation * Quaternion.Euler(0, 0, 45));
                    Instantiate(cannonBall, firePointL.position, transform.rotation * Quaternion.Euler(0, 0, -45));
                  
                
                    coolDownLeft = reload;
                }
            }

            if (!Input.GetKeyDown(KeyCode.X))
            {
                if (Input.GetKeyDown(KeyCode.C) && coolDownRight <= 0)
                {


                    Instantiate(cannonBall, firePointR.position, transform.rotation);
                    Instantiate(cannonBall, firePointR.position, transform.rotation * Quaternion.Euler(0, 0, 45));
                    Instantiate(cannonBall, firePointR.position, transform.rotation * Quaternion.Euler(0, 0, -45));
                    
                    coolDownRight = reload;
                }
            }*/




        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Halves health on collision
        if (other.name == "smallShip" || other.name == "medShip" || other.name == "bigShip")
        { 
                playerAttributes.instance.playerHealth -= playerAttributes.instance.playerMaxHealth / 2;
        }

        if (other.name == "planet")
        {
            playerAttributes.instance.playerHealth -= playerAttributes.instance.playerHealth;
        }

        // code to pick up items
        if (other.tag == "LootSloop")
        {
            Destroy(other.gameObject);

            if (inventory.instance.checkStorage() < playerAttributes.instance.totalStorageSpace)
            {

                int lootAmount = Random.Range(0, 2);
                int loot = 0;
                do
                {
                    calculateSmallLoot();
                    loot++;

                } while (loot < lootAmount);
            }
        }

        if (other.tag == "LootCaravel")
        {
            Destroy(other.gameObject);
            if (inventory.instance.checkStorage() < playerAttributes.instance.totalStorageSpace)
            {

                int lootAmount = Random.Range(1, 4);
                int loot = 0;
                do
                {
                    calculateMedLoot();
                    loot++;

                } while (loot < lootAmount);


            }
        }

        if (other.tag == "LootBrigatine")
        {
            Destroy(other.gameObject);

            if (inventory.instance.checkStorage() < playerAttributes.instance.totalStorageSpace)
            {

                int lootAmount = Random.Range(3, 8);
                int loot = 0;
                do
                {
                    calculateBigLoot();
                    loot++;

                } while (loot < lootAmount);
            }
        
        }
    }
    //For health bar
    float calculateHealth()
    {
        return playerAttributes.instance.playerHealth / playerAttributes.instance.playerMaxHealth;
    }
    //For sail health
    float calculateSailHealth()
    {
        return playerAttributes.instance.sailHealth / playerAttributes.instance.maxSailHealth;
    }
    //From here onwards is code to calculate drop based on brief
    void calculateSmallLoot()
    {
        int lootType = Random.Range(0, 100);

        int goldAmount = Random.Range(2, 8);

        /*switch (lootType)
        {
            case 0:
                inventory.instance.changeGrain(1);
                inventory.instance.changeGold(goldAmount);
                break;
            case 1:
                inventory.instance.changeFish(1);
                inventory.instance.changeGold(goldAmount);
                break;
            case 2:
                inventory.instance.changeOil(1);
                inventory.instance.changeGold(goldAmount);
                break;
            case 3:
                inventory.instance.changeWood(1);
                inventory.instance.changeGold(goldAmount);
                break;
            case 4:
                inventory.instance.changeBrick(1);
                inventory.instance.changeGold(goldAmount);
                break;
            case 5:
                inventory.instance.changeIron(1);
                inventory.instance.changeGold(goldAmount);
                break;
            case 6:
                inventory.instance.changeRum(1);
                inventory.instance.changeGold(goldAmount);
                break;*/

        if(lootType <= 25)
        {
            inventory.instance.changeGrain(1);
            inventory.instance.changeGold(goldAmount);
        }

        if(lootType > 25 && lootType <= 47)
        {
            inventory.instance.changeFish(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 47 && lootType <= 65)
        {
            inventory.instance.changeOil(1);
            inventory.instance.changeGold(goldAmount);
        }

        if(lootType > 65 && lootType <= 78)
        {
            inventory.instance.changeWood(1);
            inventory.instance.changeGold(goldAmount);
        }

        if(lootType > 78 && lootType <= 88)
        {
            inventory.instance.changeBrick(1);
            inventory.instance.changeGold(goldAmount);
        }

        if(lootType > 88 && lootType <= 96)
        {
            inventory.instance.changeIron(1);
            inventory.instance.changeGold(goldAmount);
        }

        if(lootType > 96 && lootType <= 100)
        {
            inventory.instance.changeRum(1);
            inventory.instance.changeGold(goldAmount);
        }

    }


    void calculateMedLoot()
    {
        int lootType = Random.Range(0, 100);

        int goldAmount = Random.Range(4, 15);


        if (lootType <= 22)
        {
            inventory.instance.changeGrain(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 22 && lootType <= 41)
        {
            inventory.instance.changeFish(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 41 && lootType <= 56)
        {
            inventory.instance.changeOil(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 56 && lootType <= 68)
        {
            inventory.instance.changeWood(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 68 && lootType <= 79)
        {
            inventory.instance.changeBrick(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 79 && lootType <= 88)
        {
            inventory.instance.changeIron(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 88 && lootType <= 94)
        {
            inventory.instance.changeRum(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 94 && lootType <= 98)
        {
            inventory.instance.changeSilk(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 98 && lootType <= 100)
        {
            inventory.instance.changeEmerald(1);
            inventory.instance.changeGold(goldAmount);
        }
    }

    void calculateBigLoot()
    {
        int lootType = Random.Range(0, 100);

        int goldAmount = Random.Range(8, 25);


        if (lootType <= 18)
        {
            inventory.instance.changeGrain(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 18 && lootType <= 34)
        {
            inventory.instance.changeFish(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 34 && lootType <= 47)
        {
            inventory.instance.changeOil(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 47 && lootType <= 59)
        {
            inventory.instance.changeWood(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 59 && lootType <= 70)
        {
            inventory.instance.changeBrick(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 70 && lootType <= 80)
        {
            inventory.instance.changeIron(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 80 && lootType <= 88)
        {
            inventory.instance.changeRum(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 88 && lootType <= 93)
        {
            inventory.instance.changeSilk(1);
            inventory.instance.changeGold(goldAmount);
        }

        if (lootType > 93 && lootType <= 97)
        {
            inventory.instance.changeSilverware(1);
            inventory.instance.changeGold(goldAmount);
        }

        if(lootType > 97 && lootType <= 100)
        {
            inventory.instance.changeEmerald(1);
            inventory.instance.changeGold(goldAmount);
        }
    }

float timer()
    {
        float time = 10.0f;

        do
        {
            time -= Time.deltaTime;
        } while (time > 0);

        return time;
    }
}