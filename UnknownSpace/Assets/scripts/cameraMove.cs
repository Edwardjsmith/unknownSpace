using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {
    public GameObject player;
    public float cameraHeight;

    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.z += cameraHeight;
        transform.position = pos;
    }

}
