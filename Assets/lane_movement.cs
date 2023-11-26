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
            //Move right
            targetLane--;
        }
    }
}
