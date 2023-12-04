using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class move : MonoBehaviour
{

    public static bool isMovementAllowed = true;
    float movementSpeed;
    public static float speedIncreasementFactor = 1.0f;
    [SerializeField] TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        if (isMovementAllowed)
        {
            movementSpeed = 6.0f + speedIncreasementFactor;
            transform.position += new Vector3(0, 0, movementSpeed) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("destroy_trigger")){
            Destroy(gameObject);
        }
    }
}
