using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycledObjScript : MonoBehaviour
{
    public FirstPersonMovement playerPoints;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
            playerPoints.RecyclingPoints++;
            
        }
    }
}
