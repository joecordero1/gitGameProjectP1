using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoBoxScript : MonoBehaviour
{
    public RayCastShoot playerShots;
    public TMP_Text CounterBulletsText;   // Texto para mostrar puntos
    void Start()
    {
        CounterBulletsText.SetText("Bullets left: " + playerShots.bulletsLeft);
    }
    void Update()
    {
        CounterBulletsText.SetText("Bullets left: " + playerShots.bulletsLeft);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            
            playerShots.bulletsLeft += 10;
            
            Debug.Log("Munición aumentada +10: "+playerShots.bulletsLeft);
            Destroy(gameObject);
        }
    }
}
