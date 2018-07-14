using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeShip : MonoBehaviour {

    public Text currentLevel;
    public Button upgradeButton;
    public Button repairButton;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

        //Changes buttonn to reflect whether you can upgrade based on level and money
    {
        currentLevel.text = "Ship level: " + playerAttributes.instance.shipUpgradeLevel.ToString();

        if (playerAttributes.instance.shipUpgradeLevel == 1 && inventory.instance.checkGold() >= 1)
        {
            upgradeButton.GetComponentsInChildren<Text>()[0].text = "Upgrade your ship!";
        }
        else if (playerAttributes.instance.shipUpgradeLevel == 2 && inventory.instance.checkGold() >= 3)
        {
            upgradeButton.GetComponentsInChildren<Text>()[0].text = "Upgrade your ship!";
        }
        else
        {
            upgradeButton.GetComponentsInChildren<Text>()[0].text = "You cannot upgrade";
        }

        if(inventory.instance.checkGold() >= 2)
        {
            repairButton.GetComponentsInChildren<Text>()[0].text = "Repair your ship!";
        }
        else
        {
            repairButton.GetComponentsInChildren<Text>()[0].text = "Not enough gold to repair..";
        }
    }

    public void repairShip()
    {
        //Allows the player to retrun to max health for a fee between raids
        //if(playerAttributes.instance.playerHealth != playerAttributes.instance.playerMaxHealth && inventory.instance.checkGold() < 2)
        {
            playerAttributes.instance.playerHealth = playerAttributes.instance.playerMaxHealth;
            playerAttributes.instance.sailHealth = playerAttributes.instance.maxSailHealth;
            inventory.instance.changeGold(-2);
        }
    }
    //implements the actual upgrade for a fee
    public void upgrade()
    {
        if (playerAttributes.instance.shipUpgradeLevel == 1 && inventory.instance.checkGold() >= 100)
        {
            playerAttributes.instance.shipUpgradeLevel++;

            inventory.instance.changeGold(-100);
        }

        else if (playerAttributes.instance.shipUpgradeLevel == 2 && inventory.instance.checkGold() >= 300)
        {
            playerAttributes.instance.shipUpgradeLevel++;

            inventory.instance.changeGold(-300);

           
        }
       
       

    }

   

}
