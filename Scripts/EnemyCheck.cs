using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    private float currentHealth;
    [SerializeField] private Healthbar healthbar;

    void Start() {
        currentHealth = maxHealth;
        healthbar.UpdateHealthbar(maxHealth, currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
           //Destroy(transform.parent.gameObject);
           currentHealth -= 25f;
           // DAMAGE EFFECT TODO
        } else if (collision.gameObject.tag == "Food") {
            currentHealth += 25f;
            Destroy(collision.gameObject);
            // EAT EFFECT TODO
        }

        if (currentHealth <= 0) {
            Destroy(transform.parent.gameObject);
        } else if (currentHealth >= 100) {
            currentHealth = 100;
        }

        healthbar.UpdateHealthbar(maxHealth, currentHealth);
    }



}
