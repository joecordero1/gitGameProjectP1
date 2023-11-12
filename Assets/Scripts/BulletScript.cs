using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private FirstPersonMovement playerHealth;
    public HealthScript _healthbar;
    public GameOverScript _GameOverScene;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<FirstPersonMovement>();
        playerHealth.currentHealth = playerHealth.health;
        _healthbar.UpdateHealthbar(playerHealth.health,playerHealth.currentHealth);
    }
        
    

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            playerHealth.health -= 10;
            _healthbar.UpdateHealthbar(playerHealth.health,playerHealth.currentHealth);
            Debug.Log("La bala ha alcanzado al jugador, salud: "+playerHealth.health);
            Destroy(gameObject);
            if(playerHealth.health < 0){
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        _GameOverScene.Setup();
        Time.timeScale = 0; // Pausar el juego
    }
}
