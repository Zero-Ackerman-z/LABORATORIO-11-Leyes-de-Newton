using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 1f; 
    public float backgroundWidth; 

    private Vector3 startPosition; 

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, backgroundWidth);
        Vector3 newPos = startPosition + Vector3.left * newPosition;
        transform.position = newPos;
    }
}
