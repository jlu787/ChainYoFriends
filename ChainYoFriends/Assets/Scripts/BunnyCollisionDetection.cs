using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using Spine;
using UnityEngine;

public class BunnyCollisionDetection : MonoBehaviour
{
    public BunnyHealth HealthLevel { get; set; } = BunnyHealth.Bunny;
    private DumbFukChainManager _manager;

    public void Hurt()
    {
        if (HealthLevel == BunnyHealth.DeadBunny)
        {
            _manager.Kill(gameObject);
        }

        HealthLevel--;
        SetSkin();
    }

    public void Heal()
    {
        HealthLevel = BunnyHealth.Bunny;
        SetSkin();

    }

    public void SetSkin()
    {
        Skeleton skeleton = GetComponentInChildren<SkeletonAnimation>().skeleton;
        switch (HealthLevel)
        {
            case BunnyHealth.Bunny:
                skeleton.SetSkin("BunnyAlive");
                break;
            case BunnyHealth.ZomBunny:
                skeleton.SetSkin("BunnyGore");
                break;
            case BunnyHealth.DeadBunny:
                skeleton.SetSkin("BunnyBones");
                break;
             default:
                 Debug.LogError("OOPS :(");
                 break;
        }
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
        if (!gameObject.CompareTag("Leader"))
        {
            return;
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Bunny") )
        {
            Destroy(col.gameObject);
            Debug.Log("caugh.");
            transform.parent.gameObject.GetComponent<DumbFukChainManager>().AddToChain(col.gameObject.GetComponent<BunnyScript>().Health);
        }
    }
}
