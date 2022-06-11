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
        waveSpeed = UnityEngine.Random.value;
        transform.Translate(Vector2.right * waveSpeed * (Time.deltaTime/2));
        if (transform.position.x > 14)
        {
            waveOutOfView?.Invoke();
            Destroy(gameObject);
        }
    }
}
