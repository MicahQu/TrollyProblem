using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class TrainMoveScript : MonoBehaviour
{
    public float MoveSpeed = 5;
     private float RotationSpeed = .7f; // Speed of rotation
    private bool leverFlipped = false;
   

    private Vector3 targetPositionA = new Vector3(14.39f, 0f, 11.19f);
    private Vector3 targetPositionB = new Vector3(-43.04f, 0f, 11.19f);
   
    private Vector3 targetPositionC = new Vector3(-1.44f, 0f, 1.43f);
    private Vector3 targetPositionD = new Vector3(-38.52f, 0f, -40.38f);

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
                    StartCoroutine(SmoothRotateTo(0, 41.254f, 0)); // Use StartCoroutine here
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
                // StartCoroutine(SmoothRotateTo(0, 90, 0)); // Use StartCoroutine here
                currentTarget = targetPositionD;
               
            }
        }
    }
    public void FlipLever(){
        leverFlipped = !leverFlipped;
    }
    public IEnumerator SmoothRotateTo(float x, float y, float z)
    {
        Debug.Log("Rotating");
        Quaternion targetRotation = Quaternion.Euler(x, y, z);
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f) // Threshold to stop
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            yield return null; // Wait until the next frame
        }

        // Ensure we snap to the target rotation at the end
        transform.rotation = targetRotation;
    }


}
