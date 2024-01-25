using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecycledObjScript : MonoBehaviour
{
    public FirstPersonMovement playerPoints;
    public TMP_Text CounterPointsText;   // Texto para mostrar puntos

    public RecyclableFlyweight dataSO;
    void Start()
    {
        CounterPointsText.SetText("New points: " + playerPoints.RecyclingPoints);
    }
    void Update()
    {
        CounterPointsText.SetText("New points: " + playerPoints.RecyclingPoints);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
            playerPoints.RecyclingPoints = playerPoints.RecyclingPoints + dataSO.puntos;
        }
    }
}