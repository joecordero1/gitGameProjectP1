using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string sceneName;
     public void PlayGame()
    {
        Debug.Log("INICIA el juego");
       SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {

        Application.Quit();
    }
}
