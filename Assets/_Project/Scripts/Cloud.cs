using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public static Action cloudOutOfView;
    public float cloudSpeed = 1;
    void Update()
    {
        cloudSpeed = UnityEngine.Random.value;
        transform.Translate(Vector2.right * cloudSpeed * (Time.deltaTime/3));
    }

    void OnBecameInvisible() {
            Destroy(this);
    }
}
