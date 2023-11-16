using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecycledObjScript : MonoBehaviour
{
    public FirstPersonMovement playerPoints;
    public TMP_Text CounterPointsText;   // Texto para mostrar puntos
    void Start()
    {
        CounterPointsText.SetText("Recycling points: " + playerPoints.RecyclingPoints);
    }
    void Update()
    {
        CounterPointsText.SetText("Recycling points: " + playerPoints.RecyclingPoints);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
            playerPoints.RecyclingPoints++;
            
        }
    }
}
