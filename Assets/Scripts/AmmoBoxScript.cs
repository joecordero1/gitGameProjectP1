using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxScript : MonoBehaviour
{
    public RayCastShoot playerShots;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            
            playerShots.bulletsLeft += 10;
            
            Debug.Log("Munición aumentada +10: "+playerShots.bulletsLeft);
            Destroy(gameObject);
        }
    }
}
