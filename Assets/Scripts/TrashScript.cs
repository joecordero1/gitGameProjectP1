using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashScript : MonoBehaviour
{
    public int Points;
    public GameOverScript _GameOverScene;
    public AudioSource backgroundMusic;
    public TMP_Text totalPointsText;   // Texto para mostrar puntos
    void Start()
    {
        totalPointsText.SetText("Recycled points: " + PlayerData.Instance.playerPoints);
    }
    void Update()
    {
        totalPointsText.SetText("Recycled points: " + PlayerData.Instance.playerPoints);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Suponiendo que other es el jugador
            FirstPersonMovement player = other.GetComponent<FirstPersonMovement>();

            if (player != null)
            {
                // Añadir puntos al total y resetear los puntos de reciclaje del jugador
                totalPointsText.SetText("Recycled points: " + PlayerData.Instance.playerPoints);
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
