using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DumbFukChainManager : MonoBehaviour
{

    public List<GameObject> bunnyChain;
    public int currentChainLength = 2;
    public GameObject bunnyPrefab;
    public float frequency = 0.5f;
    public float bunnyMass = 1f;
    public float bunnyLinearDrag = 0.05f;
    public float bunnyAngularDrag = 0f;

    private float counter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = currentChainLength; i<bunnyChain.Count; i++)
        {
            enableBunny(i, false);
        }
        SetLeader();
    }

    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= 1f / frequency)
        {
            counter = 0f;
            bunnyChain[6].GetComponent<BunnyCollisionDetection>().Hurt();
        }
    }

    public void Kill(GameObject bunny)
    {
        int killIndex = -1;
        for (int i = 0; i < bunnyChain.Count; i++)
        {
            if (!ReferenceEquals(bunny, bunnyChain[i])) continue;
            killIndex = i;
            break;
        }

        if (killIndex == -1)
        {
            return;
        }

        for (int i = killIndex; i < bunnyChain.Count; i++)
        {
            RemoveFromChain();
        }
    }

    public void AddToChain()
    {
        enableBunny(currentChainLength, true);
        currentChainLength++;
        SetLeader();
    }

    public void RemoveFromChain()
    {
        enableBunny(currentChainLength - 1, false);
        currentChainLength--;
        SetLeader();
    }

    private void SetLeader()
    {
        for (int i = 0; i < bunnyChain.Count; i++)
        {
            bunnyChain[i].tag = "Link";
        }
        

        bunnyChain[currentChainLength - 1].tag = "Leader";

        for (int i = currentChainLength; i < bunnyChain.Count; i++)
        {
            bunnyChain[i].layer = LayerMask.NameToLayer("Default");
        }
    }
    

    private void enableBunny(int index, bool state)
    {
        Debug.Log("Enabling bunny: " + index);
        GameObject bunny = bunnyChain[index];
        SpriteRenderer render = bunny.GetComponent<SpriteRenderer>();
        render.enabled = state;

    }
}
