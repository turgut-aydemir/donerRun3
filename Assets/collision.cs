using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("AyranTag")){
            Debug.Log("Sexy Score");
        }
    }
}
