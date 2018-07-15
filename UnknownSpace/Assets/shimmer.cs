using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shimmer : MonoBehaviour
{
    float maxAlpha = 0.3f;
    float minAlpha = 0.01f;

    SpriteRenderer sprite;

    private float startTime;
    public float duration = 5.0f;
    float fixedDuration;

    // Use this for initialization
    void Start()
    {
        fixedDuration = duration;
        startTime = Time.time;
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0.01f);
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sprite.color = new Color(1f, 1f, 1f, Mathf.PingPong(Time.time / duration, maxAlpha) + 0.1f);
    }

    private void Update()
    {
        StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {
        if(duration < fixedDuration)
        {
            yield return new WaitForSeconds(1.5f);
            duration = fixedDuration;
        }
        else
        {
            yield return null;
        }
    }
}

