using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float score = 0;
    [SerializeField] public TextMeshProUGUI scoreText;
    public static Score scoreObject;

    private void Awake() {
        scoreObject = this;
    }

    public static void Increase()
    {
        scoreObject.score++;
        //Score.text = "1";
        scoreObject.scoreText.text = scoreObject.score.ToString();
    }

    static void Start() {

    }

    static void Update()
    {

    }

}
