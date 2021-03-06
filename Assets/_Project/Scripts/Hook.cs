using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private float originalYPos;
    [SerializeField] private float startYPos;
    [SerializeField] private float targetYPos;
    
    [SerializeField] private float timeToMoveToTarget = 2f;
    [SerializeField] private float currentTimeToMoveToTarget = 0;
    [SerializeField] private bool throwen = false;

    [SerializeField] private int trashCollectedCount = 0;
    public static Action<float> scoreChanged;

    [SerializeField] private int TRASH_TO_BE_COLLECTED = 0;
    [SerializeField] private Score scoreBehaviour;

    private void Start()
    {
        originalYPos = transform.position.y;
        startYPos = originalYPos;
        targetYPos = originalYPos;
        scoreBehaviour = FindObjectOfType<Score>();
    }

    private void Update()
    {
        MoveHook();
        DetectTrash();
    }

    private void MoveHook()
    {
        currentTimeToMoveToTarget += Time.deltaTime;
        float _targetYPos = Mathf.Lerp(startYPos, targetYPos, currentTimeToMoveToTarget / timeToMoveToTarget);
        transform.position = new Vector3(transform.position.x, _targetYPos, transform.position.z);

        if (currentTimeToMoveToTarget / timeToMoveToTarget > 1 && throwen)
        {
            targetYPos = originalYPos;
            startYPos = transform.position.y;
            throwen = false;
            currentTimeToMoveToTarget = 0;
        }
    }

    private void DetectTrash()
    {
        Collider2D[] trashCollided = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        for (int i = 0; i < trashCollided.Length; i++)
        {
            if (trashCollided[i] != null && trashCollided[i].CompareTag("Trash"))
            {
                scoreChanged?.Invoke(1);
                if (scoreBehaviour.GetScore() >= TRASH_TO_BE_COLLECTED)
                {
                    scoreBehaviour.MoveToNextLevel();
                }
            }
            else
            {
                scoreBehaviour.ShowGameOver();
            }
            Destroy(trashCollided[i].gameObject);
        }
    }

    public bool IsHookProcessing()
    {
        if (currentTimeToMoveToTarget / timeToMoveToTarget > 1 && !throwen)
        {
            return false;
        }

        return true;
    }

    public void Throw()
    {
        currentTimeToMoveToTarget = 0;
        throwen = true;
        startYPos = transform.position.y;
        targetYPos = transform.position.y - 5;
    }
}
