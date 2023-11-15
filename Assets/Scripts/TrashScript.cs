using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    // Start is called before the first frame update
    public FirstPersonMovement playerPoints;
    public int Points;
    public GameOverScript _GameOverScene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Points = Points + playerPoints.RecyclingPoints;
            playerPoints.RecyclingPoints = 0;
            if(Points >= 10){
                //you win canvas
                Debug.Log("GANA");
                GameOver();
            }
        }
    }
    public void GameOver()
    {
        _GameOverScene.Setup();
        Time.timeScale = 0; // Pausar el juego
    }
}
