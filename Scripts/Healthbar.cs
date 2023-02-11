using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    
    [SerializeField] private Image healthbarSprite;

    public void UpdateHealthbar(float maxHealth, float currentHealth) {
        healthbarSprite.fillAmount = currentHealth / maxHealth;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
