using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private Transform boatTransform;
    [SerializeField] private Camera mainCameraRef;

    [SerializeField] private float isMovingWithMouse = 0;
    [SerializeField] private float boatStartXPos;
    [SerializeField] private float boatTargetXPos;

    [SerializeField] private float boatMoveSpeed = 10f;
    [SerializeField] private float timeToMoveToTarget = 0;
    [SerializeField] private float currentTimeToMoveToTarget = 0;

    [SerializeField] private LineRenderer hookConnectorLine;

    [SerializeField] private Transform hookOriginPoint;
    [SerializeField] private Transform hookConnectionPoint;
    [SerializeField] private Hook hook;
    void Start()
    {
        boatTransform = transform;
        mainCameraRef = Camera.main;
    }
    
    void Update()
    {
        GetInput();
        MoveBoat();
        HandleHookConnection();
    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            HandleMouseInput();
        }
        
        if (Input.GetMouseButtonDown(1) && !hook.IsHookProcessing())
        {
            HandleHookThrow();
        }
    }

    private void HandleMouseInput()
    {
        Vector2 mousePosWorld = mainCameraRef.ScreenToWorldPoint(Input.mousePosition);
        float mouseXPos = mousePosWorld.x;
        BoatDirection boatDirection = BoatDirection.Left;

        if (mouseXPos < boatTransform.position.x)
        {
            //Move Left
            Debug.Log("Move Left");
            boatDirection = BoatDirection.Left;
        }

        else
        {
            //Move Right
            Debug.Log("Move Right");
            boatDirection = BoatDirection.Right;
        }

        FlipBoat(boatDirection);
        boatTargetXPos = mouseXPos;
        boatStartXPos = boatTransform.position.x;
        timeToMoveToTarget = Mathf.Abs(mouseXPos - boatTransform.position.x) / boatMoveSpeed;
        currentTimeToMoveToTarget = 0;
        if (boatStartXPos == boatTargetXPos) {
            isMovingWithMouse = 0;
            } else {
            isMovingWithMouse = 1;
        }
    }

    private void FlipBoat(BoatDirection boatDirection)
    {
        if (boatDirection == BoatDirection.Left)
        {
            boatTransform.localScale = new Vector3(-1, 1, 1);
            return;
        }
        
        boatTransform.localScale = new Vector3(1, 1, 1);
    }

    private void MoveBoat()
    {
        //boatStartXPos = boatStartXPos + 1;
        currentTimeToMoveToTarget += Time.deltaTime / 2;
        float targetXPos = Mathf.Lerp(boatStartXPos, boatTargetXPos, currentTimeToMoveToTarget / timeToMoveToTarget);
        boatTransform.position = new Vector3(targetXPos, boatTransform.position.y, boatTransform.position.z);
    }

    private void HandleHookThrow()
    {
        hook.Throw();
    }

    private void HandleHookConnection()
    {
        hookConnectorLine.positionCount = 2;
        hookConnectorLine.SetPosition(0, hookOriginPoint.position);
        hookConnectorLine.SetPosition(1, hookConnectionPoint.position);
    }
}

public enum BoatDirection
{
    Left,
    Right
}
