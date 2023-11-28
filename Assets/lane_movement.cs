using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lane_movement : MonoBehaviour
{
    private Transform Player;
   

    // 1 for middleLane, 2 for leftLane, 0 for rightLane
    private int targetLane = 1;

    //movement speed
    public float moveSpeed = 5.0f;
    public float speedIncreasePerPoint = 0.01f;

    //public float jumpForce = 7.0f; // Adjust the jump force as needed

    //private bool isGrounded; // Check if the player is on the ground

    private void Start()
    {
        Player = GetComponent<Transform>();
        
    }

    private void Update()
    {
       
        Vector3 targetPosition = new Vector3(targetLane * 6.207f, -0.72f, 14.089f);

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
            Debug.Log("D pressed");
            //Move right
            targetLane--;
        }

        /*
        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Debug.Log("W pressed");
            // Apply a vertical force for jumping
            Player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        CheckGrounded();

        */
    }
    /*
    private void CheckGrounded()
    {
        float raycastDistance = 0.2f; // Adjust the distance based on your needs
        Vector3 raycastOrigin = Player.position + Vector3.up * 0.1f; // Adjust the height above the player's position

        // Cast a ray downwards to check if the player is close to the ground
        if (Physics.Raycast(raycastOrigin, Vector3.down, raycastDistance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    */
}
