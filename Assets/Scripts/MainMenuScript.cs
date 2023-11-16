using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string sceneName;
    public GameOverScript _gameOver;
     public void PlayGame()
    {
        Debug.Log("INICIA el juego");
        _gameOver.ResetGame();
        
       SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {

        Application.Quit();
    }
}
