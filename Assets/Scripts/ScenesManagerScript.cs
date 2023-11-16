using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManagerScript : MonoBehaviour
{
    public static string previousLevel; 

    public void LoadLevel(string levelName)
    {
        Time.timeScale = 1;
        previousLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name; // Guardar la escena actual
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName); // Cargar una nueva escena
    }
    public void LoadAgain(string levelName)
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName); // Cargar una escena de nuevo
    }

    public void LoadPreviousLevel()
    {
        if (!string.IsNullOrEmpty(previousLevel))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(previousLevel); // Cargar la escena previa
        }
        else
        {
            Debug.Log("No hay escena previa registrada");
            // Puedes manejar qué sucede si no hay escena previa registrada, por ejemplo, cargar una escena por defecto.
        }
    }
}
