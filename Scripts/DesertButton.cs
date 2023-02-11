using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesertButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Endless 2", LoadSceneMode.Single);
    }
}
