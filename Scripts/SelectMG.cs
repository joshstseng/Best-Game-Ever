using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMG : MonoBehaviour
{

    [SerializeField] GameObject MG;

    public void selMG()
    {
        MG.SetActive(true);
    }
}
