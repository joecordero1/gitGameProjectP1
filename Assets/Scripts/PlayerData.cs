using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public string playerName;
    public int playerPoints;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Método para añadir puntos
    public void AddPoints(int pointsToAdd)
    {
        playerPoints += pointsToAdd;
    }
    public void ResetPlayerPoints()
    {
        playerPoints = 0;
    }
    public void ResetPlayerName()
    {
        playerName = null;
        playerPoints = 0;
    }
}
