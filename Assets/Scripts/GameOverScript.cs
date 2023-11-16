using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public RayCastShoot rayCastShootScript;
    // Start is called before the first frame update
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

    // Llamar a este método cuando se reinicie el juego
    public void ResetGame()
    {
        // Opcionalmente, restablecer el estado de juego aquí

        // Bloquear y ocultar el cursor nuevamente para el juego
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
