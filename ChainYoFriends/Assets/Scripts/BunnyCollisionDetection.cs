using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyCollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entered.");
        if (col.gameObject.layer == LayerMask.NameToLayer("Bunny"))
        {
            Destroy(col.gameObject);
            Debug.Log("caugh.");
            transform.parent.gameObject.GetComponent<DumbFukChainManager>().AddToChain();
        }
    }
}
