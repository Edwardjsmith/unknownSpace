using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAsteroids : MonoBehaviour {

    int currentAsteroids = 0;
    int maxAsteroids = 10;
    public GameObject[] asteroids;

  float targetTime = 20.0f;

    
    

    public float xMin;
    public float xMax;

    public float yMin;
    public float yMax;

    GameObject sAsteroid;

    // Use this for initialization
    void Start ()
    {

        

    }

    // Update is called once per frame
    void Update ()
    {
        targetTime -= Time.deltaTime;


        if (currentAsteroids < maxAsteroids)

        {
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            sAsteroid = asteroids[Random.Range(0, asteroids.Length)];
            Instantiate(sAsteroid, pos, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
            currentAsteroids++;
        }

        if(targetTime <= 0)
        {
            currentAsteroids -= maxAsteroids;
            targetTime = 20.0f;
        }



    }


}
