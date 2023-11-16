using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonWritter : MonoBehaviour
{
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
    public string jsonFilePath =  "/playerlist.json"; // Ruta al archivo JSON

    public void AddPlayerData(string playerName, int points)
    {
        // Crear un nuevo jugador y añadirlo a la lista
        Player newPlayer = new Player();
        newPlayer.playerName = playerName;
        newPlayer.playerPoints = points.ToString();
        myPlayerList.players.Add(newPlayer);

        // Guardar la lista actualizada en un archivo JSON
        WriteJson();
    }

    public void WriteJson()
    {
        string strOut = JsonUtility.ToJson(myPlayerList, true); // Indentado para una mejor lectura
        File.WriteAllText(Application.dataPath + jsonFilePath, strOut);
    }

    // Opcional: Método para cargar datos desde el archivo JSON
    public void LoadJson()
    {
        string fullPath = Application.dataPath + jsonFilePath;
        if (File.Exists(fullPath))
        {
            string jsonData = File.ReadAllText(fullPath);
            myPlayerList = JsonUtility.FromJson<PlayersList>(jsonData);
        }
    }

    // Opcional: Puedes llamar a LoadJson en Start si quieres cargar los datos al iniciar
    void Start()
    {
        LoadJson();
    }
}
