using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyCollisionDetection : MonoBehaviour
{
    private enum BunnyHealth
    {
        Bunny = 2,
        ZomBunny = 1,
        DeadBunny = 0
    };

    private BunnyHealth _healthLevel = BunnyHealth.Bunny;
    private DumbFukChainManager _manager;

    public void Hurt()
    {
        if (_healthLevel == BunnyHealth.DeadBunny)
        {
            _manager.Kill(gameObject);
        }
        _healthLevel = _healthLevel - 1;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _manager = gameObject.GetComponentInParent(typeof(DumbFukChainManager)) as DumbFukChainManager;
        if (_manager == null)
            Debug.LogError("Chain Manager not found");
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
