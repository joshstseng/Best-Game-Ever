using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int score = 0;
    [SerializeField] private Text pineapplesText;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] public Text finalScoreText;
    [SerializeField] public GameObject finalScoreCanvas;

    private void Start()
    {
        finalScoreCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Pineapple")) {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            score++;
            pineapplesText.text = "Score: " + score;
        }
        
    }

    private void showFinalScore()
    {
        finalScoreCanvas.SetActive(true);
        finalScoreText.text = "Final Score: " + score;
    }
}
