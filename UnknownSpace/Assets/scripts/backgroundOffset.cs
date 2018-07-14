using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundOffset : MonoBehaviour {

    public GameObject player;
	
	// Update is called once per frame
	void Update ()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        Material material = mesh.material;
        Vector2 materialOffset = material.mainTextureOffset;

        transform.position = player.transform.position - new Vector3(0, 0, -10);

        materialOffset.x = transform.position.x / transform.localScale.x;
        materialOffset.y = transform.position.y / transform.localScale.y;
        material.mainTextureOffset = materialOffset;

    }
}
