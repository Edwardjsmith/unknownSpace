using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour {

   
    public Button sellGrainButton;
    public Button sellFishButton;
    public Button sellOilButton;
    public Button sellWoodButton;
    public Button sellBrickButton;
    public Button sellIronButton;
    public Button sellRumButton;
    public Button sellSilkButton;
    public Button sellSilverwareButton;
    public Button sellEmeraldButton;
    public Button sellAllButton;

    const int grainValue = 1;
    const int fishValue = 2;
    const int oilValue = 3;
    const int woodValue = 5;
    const int brickValue = 8;
    const int ironValue = 10;
    const int rumValue = 15;
    const int silkValue = 20;
    const int silverwareValue = 30;
    const int emeraldValue = 50;

 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        //Will update buttons to say there is none of that item or that you can sell if you have that item
        if (inventory.instance.checkGrain() > 0)
        {
            sellGrainButton.GetComponentsInChildren<Text>()[0].text = "Sell 1 grain for 1 gold";
        }
        else
        {
            sellGrainButton.GetComponentsInChildren<Text>()[0].text = "No grain to sell!";
        }

        if (inventory.instance.checkFish() > 0)
        {
            sellFishButton.GetComponentsInChildren<Text>()[0].text = "Sell 1 fish for 2 gold";
        }
        else
        {
            sellFishButton.GetComponentsInChildren<Text>()[0].text = "No fish to sell!";
        }

        if (inventory.instance.checkOil() > 0)
        {
            sellOilButton.GetComponentsInChildren<Text>()[0].text = "Sell 1 oil for 3 gold";
        }
        else
        {
            sellOilButton.GetComponentsInChildren<Text>()[0].text = "No oil to sell!";
        }

        if (inventory.instance.checkWood() > 0)
        {
            sellWoodButton.GetComponentsInChildren<Text>()[0].text = "Sell 1 wood for 4 gold";
        }
        else
        {
            sellWoodButton.GetComponentsInChildren<Text>()[0].text = "No wood to sell!";
        }

        if (inventory.instance.checkBrick() > 0)
        {
            sellBrickButton.GetComponentsInChildren<Text>()[0].text = "Sell 1 brick for 5 gold";
        }
        else
        {
            sellBrickButton.GetComponentsInChildren<Text>()[0].text = "No brick to sell!";
        }

        if (inventory.instance.checkIron() > 0)
        {
            sellIronButton.GetComponentsInChildren<Text>()[0].text = "Sell 1 iron for 6 gold";
        }
        else
        {
            sellIronButton.GetComponentsInChildren<Text>()[0].text = "No iron to sell!";
        }

        if (inventory.instance.checkRum() > 0)
        {
            sellRumButton.GetComponentsInChildren<Text>()[0].text = "Sell 1 rum for 7 gold";
        }
        else
        {
            sellRumButton.GetComponentsInChildren<Text>()[0].text = "No rum to sell!";
        }

        if (inventory.instance.checkSilk() > 0)
        {
            sellSilkButton.GetComponentsInChildren<Text>()[0].text = "Sell 1 silk for 8 gold";
        }
        else
        {
            sellSilkButton.GetComponentsInChildren<Text>()[0].text = "No silk to sell!";
        }

        if (inventory.instance.checkSilverware() > 0)
        {
            sellSilverwareButton.GetComponentsInChildren<Text>()[0].text = "Sell 1 silverware for 9 gold";
        }
        else
        {
            sellSilverwareButton.GetComponentsInChildren<Text>()[0].text = "No silver to sell!";
        }

        if (inventory.instance.checkEmerald() > 0)
        {
            sellEmeraldButton.GetComponentsInChildren<Text>()[0].text = "Sell 1 emerald for 10 gold";
        }
        else
        {
            sellEmeraldButton.GetComponentsInChildren<Text>()[0].text = "No emerald to sell!";
        }

        sellAllButton.GetComponentsInChildren<Text>()[0].text = "Sell all!";
    }
    //Will sell all items individually
    public void sellGrain()
    {

        if (inventory.instance.checkGrain() > 0)
        {
            inventory.instance.changeGrain(-1);
            inventory.instance.changeGold(grainValue);
        }
        else
        {
            Debug.Log("No grain to sell!");
        }
    }

    public void sellFish()
    {

        if (inventory.instance.checkFish() > 0)
        {
            inventory.instance.changeFish(-1);
            inventory.instance.changeGold(fishValue);
        }
        else
        {
            Debug.Log("No fish to sell!");
        }
    }

    public void sellOil()
    {

        if (inventory.instance.checkOil() > 0)
        {
            inventory.instance.changeOil(-1);
            inventory.instance.changeGold(oilValue);
        }
        else
        {
            Debug.Log("No oil to sell!");
        }
    }

    public void sellWood()
    {

        if (inventory.instance.checkWood() > 0)
        {
            inventory.instance.changeWood(-1);
            inventory.instance.changeGold(woodValue);
        }
        else
        {
            Debug.Log("No wood to sell!");
        }
    }

     public void sellBrick()
    {

        if (inventory.instance.checkBrick() > 0)
        {
            inventory.instance.changeBrick(-1);
            inventory.instance.changeGold(brickValue);
        }
        else
        {
            Debug.Log("No brick to sell!");
        }
    }

    public void sellIron()
    {

        if (inventory.instance.checkIron() > 0)
        {
            inventory.instance.changeIron(-1);
            inventory.instance.changeGold(ironValue);
        }
        else
        {
            Debug.Log("No iron to sell!");
        }
    }

    public void sellRum()
    {

        if (inventory.instance.checkRum() > 0)
        {
            inventory.instance.changeRum(-1);
            inventory.instance.changeGold(rumValue);
        }
        else
        {
            Debug.Log("No rum to sell!");
        }
    }
    public void sellSilk()
    {

        if (inventory.instance.checkSilk() > 0)
        {
            inventory.instance.changeSilk(-1);
            inventory.instance.changeGold(silkValue);
        }
        else
        {
            Debug.Log("No silk to sell!");
        }
    }

    public void sellSilverware()
    {

        if (inventory.instance.checkSilverware() > 0)
        {
            inventory.instance.changeSilverware(-1);
            inventory.instance.changeGold(silverwareValue);
        }
        else
        {
            Debug.Log("No silverware to sell!");
        }
    }

    public void sellEmerald()
    {

        if (inventory.instance.checkEmerald() > 0)
        {
            inventory.instance.changeEmerald(-1);
            inventory.instance.changeGold(emeraldValue);
        }
        else
        {
            Debug.Log("No emerald to sell!");
        }
    }
    public void sellAll() //Sells everything by calling all getters and setters
    {   inventory.instance.changeGold(inventory.instance.checkGrain() * grainValue);
        inventory.instance.changeGrain(-inventory.instance.checkGrain());
        
        inventory.instance.changeGold(inventory.instance.checkFish() * fishValue);
        inventory.instance.changeFish(-inventory.instance.checkFish());

        inventory.instance.changeGold(inventory.instance.checkOil() * oilValue);
        inventory.instance.changeOil(-inventory.instance.checkOil());

        inventory.instance.changeGold(inventory.instance.checkWood() * woodValue);
        inventory.instance.changeWood(-inventory.instance.checkWood());

        inventory.instance.changeGold(inventory.instance.checkBrick() * brickValue);
        inventory.instance.changeBrick(-inventory.instance.checkBrick());

        inventory.instance.changeGold(inventory.instance.checkIron() * ironValue);
        inventory.instance.changeIron(-inventory.instance.checkIron());

        inventory.instance.changeGold(inventory.instance.checkRum() * rumValue);
        inventory.instance.changeRum(-inventory.instance.checkRum());

        inventory.instance.changeGold(inventory.instance.checkSilk() * silkValue);
        inventory.instance.changeSilk(-inventory.instance.checkSilk());

        inventory.instance.changeGold(inventory.instance.checkSilverware() * silverwareValue);
        inventory.instance.changeSilverware(-inventory.instance.checkSilverware());

        inventory.instance.changeGold(inventory.instance.checkEmerald() * emeraldValue);
        inventory.instance.changeEmerald(-inventory.instance.checkEmerald());

    }
}
