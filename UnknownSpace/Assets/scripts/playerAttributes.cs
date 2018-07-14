
using UnityEngine;

public class playerAttributes : MonoBehaviour {

    public static playerAttributes instance = null;

    public float playerHealth;
    public float playerMaxHealth;
    public float playerSpeed;
    public float playerMaxSpeed;
    public float playerTurnSpeed;
    public float reloadSpeed;
    public int totalStorageSpace;

    public float sailHealth;
    public float maxSailHealth;

    public float shipUpgradeLevel = 1;
    public float damageUpgradeLevel;
    
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        
    }


    // Use this for initialization
    void Start () {

        //Sets health to max health at start and on death
        playerHealth = playerMaxHealth;
        sailHealth = maxSailHealth;




    }
	
	// Update is called once per frame
	void Update ()
    {
        //Increases player attributes on upgrade

        if (shipUpgradeLevel == 1)
        {

            playerMaxHealth = 100;
            playerSpeed = 1000 * Time.deltaTime;
            playerTurnSpeed = 20000 * Time.deltaTime;
            reloadSpeed = 200;
            maxSailHealth = 4;
            totalStorageSpace = 10;
        }

        if (shipUpgradeLevel == 2)
        {

            playerMaxHealth = 150;
            playerSpeed = 1200  * Time.deltaTime; ;
            playerTurnSpeed = 50000 * Time.deltaTime; 
            reloadSpeed = 100;
            maxSailHealth = 6;
            totalStorageSpace = 20;
        }

        if (shipUpgradeLevel == 3)
        {

            playerMaxHealth = 200;
            playerSpeed = 1500  * Time.deltaTime; ;
            playerTurnSpeed = 80000  * Time.deltaTime; ;
            reloadSpeed = 50;
            maxSailHealth = 10;
            totalStorageSpace = 30;
        }

        
    }

  


}
