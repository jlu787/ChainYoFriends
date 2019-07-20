using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerScript : MonoBehaviour
{
    public GameObject linkStart;
    public GameObject linkEnd;
    public BoxCollider2D boxStart;
    public BoxCollider2D boxEnd;

    public PlayerIndex playerIndex = PlayerIndex.One;

    private bool startFixed = true;
    private GamePadState previousState;
    private GamePadState currentState;



    // Start is called before the first frame update
    void Start()
    {
        currentState = GamePad.GetState(playerIndex);
        //linkEnd = linkStart;
    }

    // Update is called once per frame
    void Update()
    {
        previousState = currentState;
        currentState = GamePad.GetState(playerIndex);
        if (previousState.Buttons.A == ButtonState.Pressed && currentState.Buttons.A == ButtonState.Released)
        {
            if (startFixed)
            {
                //linkStart.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                //linkEnd.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                linkStart.GetComponent<PlayerControllerMovement>().enabled = true;
                linkEnd.GetComponent<PlayerControllerMovement>().enabled = false;
                //boxStart.enabled = false;
                //boxEnd.enabled = true;

                startFixed = false;
            }
            else
            {
                //linkStart.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                //linkEnd.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                linkStart.GetComponent<PlayerControllerMovement>().enabled = false;
                linkEnd.GetComponent<PlayerControllerMovement>().enabled = true;
                //boxStart.enabled = true;
                //boxEnd.enabled = false;

                startFixed = true;
            }
        }

        //if (Input.GetKeyDown("space"))
        //{
        //    if (startFixed)
        //    {
        //        linkStart.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //        linkEnd.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //        startFixed = false;
        //    }
        //    else
        //    {
        //        linkStart.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //        linkEnd.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //        startFixed = true;
        //    }
        //}

    }
}
