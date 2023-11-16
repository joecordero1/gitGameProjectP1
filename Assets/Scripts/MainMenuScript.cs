using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MainMenuScript : MonoBehaviour
{
    public GameOverScript _gameOver;
    public TMP_InputField playerNameInput;
    
    public ScenesManagerScript SceneLoader;
     public void PlayGame(TMP_InputField playerNameInput)
    {
        // Verifica si el InputField está lleno
        if (!string.IsNullOrEmpty(playerNameInput.text))
        {
            PlayerData.Instance.playerName = playerNameInput.text;
            SceneLoader.LoadLevel("SampleScene");
        }
        else
        {
            Debug.Log("Please enter a name."); // Opcional: Muestra un mensaje si el campo está vacío
        }
    }
    public void QuitGame()
    {

        EditorApplication.isPlaying = false;
    }
}
