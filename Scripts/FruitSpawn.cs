using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{

    [SerializeField] private GameObject pineapplePrefab;
    [SerializeField] private float pineappleInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnFruit(pineappleInterval, pineapplePrefab));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnFruit(float interval, GameObject fruit)
    {
        yield return new WaitForSeconds(interval);
        GameObject newFruit = Instantiate(fruit, new Vector3(transform.position.x + Random.Range(0, 40), transform.position.y + Random.Range(0, 5), 0), Quaternion.identity);
        StartCoroutine(spawnFruit(interval, fruit));
    }

}
