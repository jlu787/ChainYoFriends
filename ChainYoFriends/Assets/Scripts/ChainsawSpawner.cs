using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawSpawner : MonoBehaviour
{
    public float spawnDelay = 3.0f;
    private float spawnTimer = 0.0f;
    private float counter = 0.0f;
    public float delayTime = 15.0f;

    public GameObject Chainsaw;

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
            if (counter < delayTime)
            {
                Debug.Log("Yikes");
                counter = counter + spawnDelay;
                Debug.Log(counter);
            }
            else
            {
                Debug.Log("Chainsaww!!!");
                //spawn a chainsaw
                SpawnChainsaw();

            }
            spawnTimer = 0.0f;
        }
    }

    void SpawnChainsaw()
    {
        Vector3 v3Pos1;
        Vector3 v3Pos2;
        float randCheckLR = Random.Range(0f, 1.0f);
        if (randCheckLR <= 0.5f)
        {
            v3Pos1 = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, Random.Range(0, 1.0f), 0));
            v3Pos2 = Camera.main.ViewportToWorldPoint(new Vector3(0f, Random.Range(-0.1f, 1.1f), 0));
        }
        else
        {
            v3Pos1 = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(-0.1f, 1.1f), 1.1f, 0));
            v3Pos2 = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(-0.1f, 1.1f), -0.1f, 0));
        }
        v3Pos1.z = 0.0f;
        v3Pos2.z = 0.0f;
        GameObject chainsaw = Instantiate(Chainsaw, v3Pos1, Quaternion.identity);
        chainsaw.GetComponent<ChainsawMovementScript>().pos1 = v3Pos1;
        chainsaw.GetComponent<ChainsawMovementScript>().pos2 = v3Pos2;

    }
}
