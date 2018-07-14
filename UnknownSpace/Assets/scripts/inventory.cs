using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class inventory : MonoBehaviour {

    public static inventory instance = null;



    int gold;
    int grain;
    int fish;
    int oil;
    int wood;
    int brick;
    int iron;
    int rum;
    int silk;
    int silverware;
    int emerald;
    int storage;
   
    
    void Awake()
    {


        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        storage = grain + fish + oil + wood + brick + iron
            + rum + silk + silverware + emerald;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 30), "Gold: " + gold);
        GUI.Label(new Rect(10, 25, 150, 30), "Grain: " + grain);
        GUI.Label(new Rect(10, 40, 150, 30), "Fish: " + fish);
        GUI.Label(new Rect(10, 55, 150, 30), "Oil: " + oil);
        GUI.Label(new Rect(10, 70, 150, 30), "Wood: " + wood);
        GUI.Label(new Rect(10, 85, 150, 30), "Brick: " + brick);
        GUI.Label(new Rect(10, 100, 150, 30), "Iron: " + iron);
        GUI.Label(new Rect(10, 115, 150, 30), "Rum: " + rum);
        GUI.Label(new Rect(10, 130, 150, 30), "Silk: " + silk);
        GUI.Label(new Rect(10, 145, 150, 30), "Silverware: " + silverware);
        GUI.Label(new Rect(10, 160, 150, 30), "Emerald: " + emerald);
        GUI.Label(new Rect(10, 175, 150, 30), "Total loot: " + storage);
    }

 

    public int changeGrain(int value)
    {

        return grain += value;

    }

    public int checkGrain()
    {
        return grain;
    }


    public int checkGold()
    {
        return gold;
    }

    public int changeGold(int value)
    {
        return gold += value;
    }

    public int changeFish(int value)
    {
        return fish += value;
    }

    public int checkFish()
    {
        return fish;
    }

    public int changeOil(int value)
    {
        return oil += value;
    }

    public int checkOil()
    {
        return oil;
    }

    public int changeWood(int value)
    {
        return wood += value;
    }

    public int checkWood()
    {
        return wood;
    }

    public int changeBrick(int value)
    {
        return brick += value;
    }

    public int checkBrick()
    {
        return brick;
    }

    public int changeIron(int value)
    {
        return iron += value;
    }

    public int checkIron()
    {
        return iron;
    }

    public int changeRum(int value)
    {
        return rum += value;
    }

    public int checkRum()
    {
        return rum;
    }

    public int changeSilk(int value)
    {
        return silk += value;
    }

    public int checkSilk()
    {
        return silk;
    }

    public int changeSilverware(int value)
    {
        return silverware += value;
    }

    public int checkSilverware()
    {
        return silverware;
    }

    public int changeEmerald(int value)
    {
        return emerald += value;
    }

    public int checkEmerald()
    {
        return emerald;
    }

    public int checkStorage()
    {
        return storage;
    }

    public int changeStorage(int value)
    {
        return storage += value;
    }
}

