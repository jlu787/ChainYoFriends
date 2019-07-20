using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawn : MonoBehaviour
{
    public float spawnDelay = 3.0f;
    private float spawnTimer = 0.0f;

    public GameObject bunnyPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay)
        {
            Debug.Log("SPAWN!!!");
            //spawn a bunny
            SpawnBunny();
            spawnTimer = 0.0f;
        }
    }

    void SpawnBunny()
    {
        int spawnPointX = Random.Range(-10, 10);
        int spawnPointY = Random.Range(-5, 5);
        Vector3 spawnPos = new Vector3(spawnPointX, spawnPointY, 0);

        Instantiate(bunnyPrefab, spawnPos, Quaternion.identity);
    }
}
