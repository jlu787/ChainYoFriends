using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject linkStart;
    public GameObject linkEnd;

    private bool startFixed = true;

    // Start is called before the first frame update
    void Start()
    {
        //linkEnd = linkStart;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
			if (startFixed)
			{
				linkStart.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
				linkEnd.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
				startFixed = false;
			}
			else
			{
				linkStart.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
				linkEnd.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
				startFixed = true;
			} 
        }
       
    }
}
