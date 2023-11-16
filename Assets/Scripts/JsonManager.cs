using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO; // Para manejar archivos

public class JsonManager : MonoBehaviour
{
    public TMP_Text displayText; // Referencia al componente de texto de UI
    public string jsonFilePath = "/playerlist.json"; // Ruta al archivo JSON

    [System.Serializable]
    public class Player
    {
        public string playerName;
        public string playerPoints;
    }

    [System.Serializable]
    public class PlayersList
    {
        public List<Player> players = new List<Player>();
    }

    public PlayersList myPlayerList = new PlayersList();

    void Start()
    {
        LoadJson();
        DisplayPlayers();
    }

    void LoadJson()
    {
        // Ruta ajustada para incluir la subcarpeta Resources
        string fullPath = Path.Combine(Application.dataPath, "playerlist.json");

        if (File.Exists(fullPath))
        {
            string jsonData = File.ReadAllText(fullPath);
            myPlayerList = JsonUtility.FromJson<PlayersList>(jsonData);
        }
        else
        {
            Debug.LogError("Cannot find JSON file at: " + fullPath);
        }
    }


    // Método para mostrar los jugadores en la UI
    void DisplayPlayers()
    {
        string textToDisplay = "";
        foreach (var player in myPlayerList.players)
        {
            textToDisplay += "Name: " + player.playerName + " - Points: " + player.playerPoints + "\n";
        }
        displayText.text = textToDisplay;
    }
}
