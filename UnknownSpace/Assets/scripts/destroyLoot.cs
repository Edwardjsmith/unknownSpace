using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyLoot : MonoBehaviour {

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(gameObject, 20.0f);
	}
}
