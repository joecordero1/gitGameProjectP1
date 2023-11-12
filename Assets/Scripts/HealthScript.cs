using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image healthSprite;

    public void UpdateHealthbar(float maxHealth, float currentHealth){
        healthSprite.fillAmount = currentHealth /100;

    }
}
