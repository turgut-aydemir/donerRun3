using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lane_movement : MonoBehaviour
{
    private Transform Player;
    public Animator animator;

    // 1 for middleLane, 2 for leftLane, 0 for rightLane
    private int targetLane = 1;

    //movement speed
    public float moveSpeed = 5.0f;
    public float speedIncreasePerPoint = 0.01f;

    public float jumpForce = 5f;
    public float jumpHeightThreshold = 2f;
    private bool canJump = true;
    private float initialYPosition;
    private float initialZPosition;

    private void Start()
    {
        Player = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        initialYPosition = transform.position.y;
        initialZPosition = transform.position.z;
    }

    private void Update()
    {

        Vector3 targetPosition = new Vector3(targetLane * 6.207f, -1.5f, 14.089f);

        //For smooth movement towards new targetPosition
        Player.position = Vector3.Lerp(Player.position, targetPosition, moveSpeed * Time.deltaTime);

        //Move with keys
        if (Input.GetKeyDown(KeyCode.A) && targetLane < 2)
        {
            //Move left
            targetLane++;
        }

        if (Input.GetKeyDown(KeyCode.D) && targetLane > 0)
        {
            //Move right
            targetLane--;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.W) && IsAboveThreshold() && canJump)
        {
            Debug.Log("W pressed");
            
            Jump();
        }

        // Check if the sphere has fallen below the initial Y position and reset if needed 
        if (transform.position.y < initialYPosition)
        {
            ResetPosition();
            canJump = true; // Enable jumping again
        }

        //Roll down
        if (Input.GetKeyDown(KeyCode.S) && transform.position.z == initialZPosition)
        {
            animator.Play("RollDownAnim", 0, 0.0f);
            
        }
    }

    private void Jump()
        {
            // Apply an upward force to make the sphere jump
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }

     private bool IsAboveThreshold()
        {
            // Check if the sphere is above the desired height threshold
            return transform.position.y - initialYPosition < jumpHeightThreshold;
        }

    private void ResetPosition()
    {
        // Reset the position to the initial Y position
        transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        canJump = true; // Enable jumping again
        Debug.Log("Resetting position.");
    }



}


