using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plusHealthScript : MonoBehaviour
{
    public FirstPersonMovement playerHealth;
    public HealthScript _healthbar;
    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<FirstPersonMovement>();
        UpdateHealthBar(); // Actualiza la barra de vida al inicio
    }
    
    void UpdateHealthBar()
    {
        playerHealth.currentHealth = playerHealth.health;
        _healthbar.UpdateHealthbar(playerHealth.health, playerHealth.currentHealth);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            
            playerHealth.health = 100;
            UpdateHealthBar();
            Destroy(gameObject);
            Debug.Log("Salud restaurada: "+playerHealth.health);
            
        }
    }
}
