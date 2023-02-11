using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    bool paused = false;
    [SerializeField] GameObject pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        unpauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            pauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            unpauseGame();
        }
    }

    private void pauseGame() {
        Time.timeScale = 0;
        paused = true;
        AudioListener.pause = true;
        pauseCanvas.SetActive(true);
    }

    private void unpauseGame() {
        Time.timeScale = 1;
        paused = false;
        AudioListener.pause = false;
        pauseCanvas.SetActive(false);
    }
}
