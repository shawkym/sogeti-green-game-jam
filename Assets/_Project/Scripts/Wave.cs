using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public static Action waveOutOfView;
    public float waveSpeed = 2;
    void Update()
    {
        transform.Translate(Vector2.right * waveSpeed * Time.deltaTime);
        // if (UnityEngine.Random.value > UnityEngine.Random.value)
        //         transform.Translate(Vector2.down * waveSpeed * (Time.deltaTime/2));
        // else
        //         transform.Translate(Vector2.up * waveSpeed * (Time.deltaTime/2));
    }

    void OnBecameInvisible() {
            Destroy(this);
    }
}
