using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnIslands : MonoBehaviour {

    
    int currentIslands = 0;
    int maxIslands = 5;
    public GameObject[] islands;

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
       
        
        
        if(currentIslands < maxIslands)

        {
            spawn();
            currentIslands++;
        }
        
}

	
    void spawn()
    {
        //Spawns islands based on random coords. attempted to stop spawning on each other but didn't work
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

            GameObject sIsland = islands[Random.Range(0, islands.Length)];

        
            Instantiate(sIsland, pos, transform.rotation);
        
        
    }
}
