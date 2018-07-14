using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class winOrLose : MonoBehaviour {

    public GameObject player;

    float timer = 10;

    public static int numberOfEnemies;

    public void OnGUI()
    {
        //Displays message on win and gives the delay before going back to management
        if (numberOfEnemies <= 0)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + 10, 150, 30), "You win!");
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + 20, 150, 30), "Returning to management");


            if (timer <= 0)
            {

                SceneManager.LoadScene(1);

                numberOfEnemies = spawnEnemies.maxEnemies;
            }

            timer -= Time.deltaTime;
        }
    }


    // Use this for initialization
    void Start ()
    {
        numberOfEnemies = spawnEnemies.maxEnemies;

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Destroys player on lose, reducing loot, retting health and returning to management
        if (playerAttributes.instance.playerHealth <= 0)
        {
            Destroy(player);
            inventory.instance.changeStorage((inventory.instance.checkStorage() / 4) * -1);

            SceneManager.LoadScene(1);
            playerAttributes.instance.playerHealth = playerAttributes.instance.playerMaxHealth;
            playerAttributes.instance.sailHealth = playerAttributes.instance.maxSailHealth;

            
        }

        //Halfs player speed when sail has taken enough damage

        if (playerAttributes.instance.sailHealth <= playerAttributes.instance.sailHealth / 100 * 25)
        {
            playerAttributes.instance.playerSpeed -= playerAttributes.instance.playerSpeed / 2;
        }
    }
}
