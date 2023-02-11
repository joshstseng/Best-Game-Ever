using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFrog : MonoBehaviour
{
    [SerializeField] GameObject FrogCharacter;

    public void selFrog() {
        FrogCharacter.SetActive(true);
    }

}
