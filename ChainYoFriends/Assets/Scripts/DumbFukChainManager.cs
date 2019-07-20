using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DumbFukChainManager : MonoBehaviour
{

    public List<GameObject> bunnyChain;
    public GameObject bunny;
    public float frequency = 0.5f;
    public float spawnOffset = 0.5f;
    private float counter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= 1f/frequency && bunnyChain.Count < 10)
        {
            counter = 0f;
            Add();
        }
    }

    void Add()
    {
        GameObject lastBunny = bunnyChain.Last();
        GameObject secondToLastBunny = lastBunny;
        if (bunnyChain.Count > 2)
        {
            secondToLastBunny = bunnyChain[bunnyChain.Count - 1];
        }
        Debug.Log(Vector2.Angle(lastBunny.transform.right, secondToLastBunny.transform.right));
        
        Vector3 newBunnyPos = lastBunny.transform.position + lastBunny.transform.right * spawnOffset;
        GameObject newBunny = Instantiate(bunny, newBunnyPos, Quaternion.identity) as GameObject;
        HingeJoint2D hj = newBunny.GetComponent<HingeJoint2D>();
        hj.connectedBody = bunnyChain.Last().GetComponent<Rigidbody2D>();
        JointAngleLimits2D limits = hj.limits; 
        limits.max = lastBunny.GetComponent<HingeJoint2D>().limits.max + 30;
        limits.min = lastBunny.GetComponent<HingeJoint2D>().limits.min - 30;
        hj.limits = limits;
        bunnyChain.Add(newBunny); //probably
        newBunny.transform.rotation = lastBunny.transform.rotation;
    }
}
