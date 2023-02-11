using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrassButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Endless 1", LoadSceneMode.Single);
    }
}
