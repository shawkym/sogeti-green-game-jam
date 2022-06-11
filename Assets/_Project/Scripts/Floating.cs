using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public static Action OutOfView;
    public float floatSpeed = 1;
    void Update()
    {
        floatSpeed = UnityEngine.Random.value;
        if (UnityEngine.Random.value > UnityEngine.Random.value) {
        transform.Translate(Vector2.right * floatSpeed * (Time.deltaTime / 2));
        } else {
        transform.Translate(Vector2.left * floatSpeed * (Time.deltaTime / 3));
        }
    }
}
