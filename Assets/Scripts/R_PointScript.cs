using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class R_PointScript : MonoBehaviour
{
    public RecyclableFlyweight dataSO;
    public FirstPersonMovement playerPoints;
    public ScenesManagerScript SceneLoader;
    public string SceneName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
            playerPoints.R_Points = playerPoints.R_Points + dataSO.puntos;
            if(playerPoints.R_Points == 3){
                playerPoints.R_Points = 0;
                SceneLoader.LoadLevel(SceneName);
            }
        }
    }
}