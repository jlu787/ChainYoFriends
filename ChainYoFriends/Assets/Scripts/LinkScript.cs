using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkScript : MonoBehaviour
{

    public HingeJoint2D hinge1;
    public HingeJoint2D hinge2;

    //public void Flip();
     //Start is called before the first frame update
    void Start()
    {
        //hinge1.enabled = true;
        //hinge2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flip()
    {
        if (hinge1.enabled)
        {
            hinge1.enabled = false;
            hinge2.enabled = true;
        }
        else
        {
			hinge1.enabled = true;
            hinge2.enabled = false;
        }
    }
}
