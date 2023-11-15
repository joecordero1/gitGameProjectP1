using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class R_PointScript : MonoBehaviour
{
    public FirstPersonMovement playerPoints;
    public ScenesManagerScript SceneLoader;
    public string SceneName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
            playerPoints.R_Points++;
            if(playerPoints.R_Points == 3){
                Debug.Log("ENTRA ");
                playerPoints.R_Points = 0;
                SceneLoader.LoadLevel(SceneName);
            }
        }
    }
}
