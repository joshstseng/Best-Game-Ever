using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool dead = false;
    public float impactPower = 50f;
    [SerializeField] GameObject EnemyHeadCheck;

    [SerializeField] private AudioSource deathSoundEffect;

    
    [SerializeField] private float maxHealth = 100;
    private float currentHealth;
    [SerializeField] private Healthbar healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthbar.UpdateHealthbar(maxHealth, currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {

            currentHealth -= 100f;
            healthbar.UpdateHealthbar(maxHealth, currentHealth);
            //Knockback(collision.gameObject.GetComponent<Rigidbody2D>());

            if (currentHealth <= 0)
            {
                if (!dead)
                {
                    Die();

                }
            }
        }
        else if (collision.gameObject.CompareTag("Slime"))
        {
            currentHealth -= 25f;
            healthbar.UpdateHealthbar(maxHealth, currentHealth);
            //Knockback(collision.gameObject.GetComponent<Rigidbody2D>());

            if (currentHealth <= 0)
            {
                if (!dead)
                {
                    Die();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            //this.score++;
            currentHealth += 5f;
            if (currentHealth >= 100f) {
                currentHealth = 100f;
            }
            healthbar.UpdateHealthbar(maxHealth, currentHealth);

        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        dead = true;
        EnemyHeadCheck.SetActive(false);
        
    }
    /*
    private void showFinalScore() {
        finalScoreText.text = "Final Score: " + score;
        finalScoreCanvas.SetActive(true);
    }*/

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PlayAgainScreen() {
        SceneManager.LoadScene("Level Select", LoadSceneMode.Single);
    }

    private void Knockback(Rigidbody2D trapRB) {
        //this.rb.position = Vector2.MoveTowards(rb.position, new Vector2((-1) * trapRB.position.x, this.rb.position.y), impactPower * Time.deltaTime);
        //trapRB.position = Vector2.MoveTowards(trapRB.position, new Vector2((-1) * this.rb.position.x, (-1) * this.rb.position.y), impactPower * Time.deltaTime);
        //this.rb.velocity = new Vector2(rb.velocity.x, 0f);
        //this.rb.AddForce((trapRB.position - this.rb.position) * impactPower);
    }

}