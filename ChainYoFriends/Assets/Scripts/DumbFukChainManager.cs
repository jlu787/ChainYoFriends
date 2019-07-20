using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DumbFukChainManager : MonoBehaviour
{

    public List<GameObject> bunnyChain;
    public int currentChainLength = 2;
    public GameObject bunny;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (currentChainLength == bunnyChain.Count)
            return;

        counter += Time.deltaTime;
        if (counter >= 1f/frequency)
        {
            counter = 0f;
            AddToChain();
        }
    }

    void AddToChain()
    {
        enableBunny(currentChainLength, true);
        currentChainLength++;
    }

    private void enableBunny(int index, bool state)
    {
        Debug.Log("Enabling bunny: " + index);
        GameObject bunny = bunnyChain[index];
        SpriteRenderer render = bunny.GetComponent<SpriteRenderer>();
        render.enabled = state;
    }
}
