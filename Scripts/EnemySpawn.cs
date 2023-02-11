using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject slimePrefab;
    [SerializeField] private float slimeInterval = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(slimeInterval, slimePrefab));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
