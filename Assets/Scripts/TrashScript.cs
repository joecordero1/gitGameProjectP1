using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public int Points;
    public GameOverScript _GameOverScene;
    public AudioSource backgroundMusic;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Suponiendo que other es el jugador
            FirstPersonMovement player = other.GetComponent<FirstPersonMovement>();

            if (player != null)
            {
                // Añadir puntos al total y resetear los puntos de reciclaje del jugador
                PlayerData.Instance.AddPoints(player.RecyclingPoints);
                player.RecyclingPoints = 0;

                // Verificar si el jugador ha ganado
                if (PlayerData.Instance.playerPoints >= 30)
                {
                    GameOver();
                }
            }
        }
    }
    public void GameOver()
    {
        backgroundMusic.Stop();
        _GameOverScene.Setup();
        Time.timeScale = 0; // Pausar el juego
    }
}
