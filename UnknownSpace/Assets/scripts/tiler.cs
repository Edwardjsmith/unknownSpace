using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiler : MonoBehaviour
{
    public GameObject tile;

    public int levelSizeY = 10;
    public int levelSizeX = 10;

	// Use this for initialization
	void Start ()
    {
        tileLevel();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    

    private void tileLevel()
    {
        float tileSize = 0.64f;

        for(int i = -levelSizeY; i < levelSizeY; i++)
        {
            for(int j = -levelSizeX; j < levelSizeX; j++)
            {
                 Instantiate(tile,new Vector3(tileSize * j, tileSize *i, 0),Quaternion.identity);
                
            }
        }
    }
}
