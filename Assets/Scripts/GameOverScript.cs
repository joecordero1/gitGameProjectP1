using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public RayCastShoot rayCastShootScript;
    public ScenesManagerScript SceneLoader;
    public JsonWritter jsonWritter; // Referencia al script JsonWritter

    public void Setup()
    {
        gameObject.SetActive(true);
        if (rayCastShootScript != null)
        {
            rayCastShootScript.canShoot = false; // Desactiva la capacidad de disparar
        }

        // Hacer que el cursor sea visible y no esté bloqueado
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        if (PlayerData.Instance != null)
        {
            PlayerData.Instance.ResetPlayerPoints(); // Restablecer puntos del jugador
        }
        SceneLoader.LoadAgain("SampleScene");
    }

    public void MainMenuGame()
    {
        // Guardar los datos del jugador en el JSON y luego regresar al menú principal
        if (PlayerData.Instance != null)
        {
            jsonWritter.AddPlayerData(PlayerData.Instance.playerName, PlayerData.Instance.playerPoints);
            PlayerData.Instance.ResetPlayerName(); // Restablecer el nombre del jugador
        }
        SceneLoader.LoadAgain("MainMenu");
    }
}
