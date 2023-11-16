using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class CanvasTimerScript : MonoBehaviour
{
    private float timer = 20f;
    public TMP_Text timerSeconds;   // Texto para mostrar el timer
    public ScenesManagerScript SceneLoader;


    // Use this for initialization
    void Start()
    {
        timerSeconds = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            timerSeconds.text = timer.ToString("f2");
        }
        else
        {
            timerSeconds.text = "0.00"; // Asegúrate de mostrar 0.00 cuando el temporizador llega a cero
            // Evita que el temporizador vaya a valores negativos
            timer = 0;

            // Carga el nivel una vez que el temporizador llegue a cero
            // Asegúrate de que LevelToLoad tenga un valor asignado en el Inspector
            SceneLoader.LoadPreviousLevel();
        }
    }
}