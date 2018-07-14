using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyThis : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(gameObject, gameObject.GetComponent<Animator>().GetComponent<AnimatorClipInfo>().clip.length);
	}
}
