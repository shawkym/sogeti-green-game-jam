using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    public static Action OutOfView;
    private float floatSpeed = 0;
    private Vector2 floatDirection = Vector2.right;

    private void Start()
    {
        floatDirection = Random.value > 0.5f ? Vector2.right : Vector2.left;
        floatSpeed = Random.Range(.5f, 1.5f);
    }

    void Update()
    {
        if (transform.position.x <= -9f)
        {
            floatDirection = Vector2.right;
            floatSpeed = Random.Range(.5f, 1.5f);
        }
        else if(transform.position.x >= 9f)
        {
            floatDirection = Vector2.left;
            floatSpeed = Random.Range(.5f, 1.5f);
        }
        transform.Translate(floatDirection * floatSpeed * Time.deltaTime);
    }
}
