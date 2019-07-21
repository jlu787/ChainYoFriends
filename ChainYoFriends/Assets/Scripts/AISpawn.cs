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
        Vector3 v3Pos1;
        float randCheckLR = Random.Range(0, 1.0f);
        if (randCheckLR <= 0.5f)
        {
            v3Pos1 = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, Random.Range(0, 1.0f), 0));
        }
        else
        {
            v3Pos1 = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(-0.1f, 1.1f), 1.1f, 0));
        }
        v3Pos1.z = 0.0f;

        Instantiate(bunnyPrefab, v3Pos1, Quaternion.identity);
    }
}
