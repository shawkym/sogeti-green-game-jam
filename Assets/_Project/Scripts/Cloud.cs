using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public static Action cloudOutOfView;
    public float cloudSpeed = 0;
    void Update()
    {
        transform.Translate(Vector2.right * cloudSpeed * Time.deltaTime);
        if (transform.position.x > 14)
        {
            cloudOutOfView?.Invoke();
            Destroy(gameObject);
        }
    }
}
