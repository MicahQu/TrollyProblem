using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class TrainMoveScript : MonoBehaviour
{
    public float MoveSpeed = 5;
    private bool leverFlipped = false;

    private Vector3 targetPositionA = new Vector3(18.1f, 0f, 11.19f);
    private Vector3 targetPositionB = new Vector3(-10f, 0f, 11.19f);
    private Vector3 targetPositionC = new Vector3(10f, 0f, 0f);
    private Vector3 targetPositionD = new Vector3(-10f, 0f, 0f);

    private Vector3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("leverFlipped: " + leverFlipped);

        currentTarget = targetPositionA; // Start by heading to point A
    }

    // Update is called once per frame
    void Update()
    {
        MoveTrain();
    }

    private void MoveTrain()
    {
        // Move towards the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, MoveSpeed * Time.deltaTime);

        // If it reaches the current target
        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            Debug.Log("Reached: " + currentTarget);
            if (currentTarget == targetPositionA)
            {
                // If at point A, decide where to go based on leverFlipped
                if (leverFlipped)
                {
                    Debug.Log("Lever is flipped, heading to C");
                    currentTarget = targetPositionC; // Go to point C if leverFlipped is true
                }
                else
                {
                    Debug.Log("Lever is not flipped, heading to B");
                    currentTarget = targetPositionB; // Go to point B if leverFlipped is false
                }
            }
            else if (currentTarget == targetPositionC)
            {
                // If at point C, head to point D
                currentTarget = targetPositionD;
            }
        }
    }
}
