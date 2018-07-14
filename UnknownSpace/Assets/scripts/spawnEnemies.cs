using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour {
   
    int currentEnemies = 0;
    public static int maxEnemies = 10;

    public GameObject bigBoat;
    public GameObject medBoat;
    public GameObject smolBoat;
   

    
    public float xMin;
    public float xMax;

    public float yMin;
    public float yMax;


    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {



        if (currentEnemies < maxEnemies)

        {
            spawn();
            
        }

    }


    void spawn()
    {

        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        
        int boatType = Random.Range(0, 3);

       
        

        switch(boatType)
        {
            case 0:
                if (currentEnemies <= 7)
                {
                    Instantiate(bigBoat, pos, transform.rotation);
                    currentEnemies += 3;
                }
                break;
            case 1:
                if (currentEnemies <= 8)
                {
                    Instantiate(medBoat, pos, transform.rotation);
                    currentEnemies += 2;
                }
                break;
            case 2:
                Instantiate(smolBoat, pos, transform.rotation);
                currentEnemies++;
                break;
            default:
                break;

        }
        



        
         
        

        


    }

}
