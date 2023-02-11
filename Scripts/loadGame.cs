using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadGame : MonoBehaviour
{
    [SerializeField] GameObject CharacterSel;
    [SerializeField] GameObject loadOnGame;

    public void startGame() {
        CharacterSel.SetActive(false);
        loadOnGame.SetActive(true);
    }

}
