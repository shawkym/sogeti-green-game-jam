using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    public static Action OutOfView;
    public float floatSpeed = 1;
    public bool isDead = false;
    [SerializeField] private float timeBetweenMoves = 10f;
    [SerializeField] private float currentTimeBetweenMoves = 10f;
    [SerializeField] private float timeToMoveToTarget = 1;
    [SerializeField] private float currentTimeToMoveToTarget = 1;

    void Die() {
        isDead = true;
        transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
    }
    void Start() {

    }
    void Move() {
        //float targetXPos = Mathf.Lerp(transform.position.x  +  Random.Range(10f, 20f), transform.position.y , currentTimeToMoveToTarget / timeToMoveToTarget);
        transform.position += new Vector3(Random.Range(0.10f, 0.20f), 0, 0);
    }
    void Update()
    {
        floatSpeed = UnityEngine.Random.value;
        if (UnityEngine.Random.value > UnityEngine.Random.value) {
        transform.Translate(Vector2.right * floatSpeed * (Time.deltaTime / 2));
        } else {
        transform.Translate(Vector2.left * floatSpeed * (Time.deltaTime / 3));
        }
        currentTimeBetweenMoves -= Time.deltaTime;
        if (currentTimeBetweenMoves <= 0 && isDead == false)
        {
            Move();
            timeBetweenMoves = Random.Range(10f, 20f);
            currentTimeBetweenMoves = timeBetweenMoves;
        }
    }
}
