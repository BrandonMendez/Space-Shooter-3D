﻿using UnityEngine;
using System.Collections;

public class MovingGround : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeY;

    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.forward * newPosition;
    }

    public void SetSpeed(float speed)
    {
        scrollSpeed = speed;
    }
}
