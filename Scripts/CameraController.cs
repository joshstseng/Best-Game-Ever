using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject playerG;
    private Transform player;
    //bool characterSelected = false;


    // Start is called before the first frame update
    void Start()
    {

        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        playerG = GameObject.FindGameObjectWithTag("Player");
        player = playerG.transform;
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
