using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#


/* 
 * Script for injetinc controller support and movement
 * Assuming pre-initialized and managed by other entities
 */
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerMovement : MonoBehaviour
{
    bool playerIndexSet = false;
    public PlayerIndex playerIndex = PlayerIndex.One;
    public float playerSpeed = 10f;
    public float revSpeed = 50f;
    GamePadState state;
    GamePadState prevState;
    private Rigidbody2D rigidBodyAttachedToPlayerInGameObject;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyAttachedToPlayerInGameObject = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        // SetVibration should be sent in a slower rate.
        // Set vibration according to triggers
        //GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
        float triggers = state.Triggers.Left- state.Triggers.Right;
        //Debug.Log(triggers);
        //Debug.Log(rigidBodyAttachedToPlayerInGameObject.rotation);
        Debug.Log( triggers * revSpeed * Time.fixedDeltaTime);
        rigidBodyAttachedToPlayerInGameObject.MoveRotation(rigidBodyAttachedToPlayerInGameObject.rotation + triggers * revSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected and use it
        //if (!playerIndexSet || !prevState.IsConnected)
        //{
        //    for (int i = 0; i < 4; ++i)
        //    {
        //        PlayerIndex testPlayerIndex = (PlayerIndex)i;
        //        GamePadState testState = GamePad.GetState(testPlayerIndex);
        //        if (testState.IsConnected)
        //        {
        //            Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
        //            playerIndex = testPlayerIndex;
        //            playerIndexSet = true;
        //        }
        //    }
        //}

        prevState = state;
        state = GamePad.GetState(playerIndex);

        // Detect if a button was pressed this frame
        //if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
        //{
        //    GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
        //}
        //// Detect if a button was released this frame
        //if (prevState.Buttons.A == ButtonState.Pressed && state.Buttons.A == ButtonState.Released)
        //
        //    GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        //}

        //// Make the current object turn
        //transform.localRotation *= Quaternion.Euler(0.0f, state.ThumbSticks.Left.X * 25.0f * Time.deltaTime, 0.0f);

        //Movement via the left thumbstick
        Vector2 movementVector = new Vector2(state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y);
        movementVector = movementVector.normalized; //Normalizing just in case
        movementVector = movementVector * playerSpeed * Time.deltaTime;

        rigidBodyAttachedToPlayerInGameObject.velocity = movementVector;

        //Vector2 lookVector = new Vector2(state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y);
        //float angle = Mathf.Atan2(state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y);

        //i

        //Quaternion angles = Quaternion.LookRotation(new Vector3(state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y, 0));
        //Vector3 whateveryouwanttocallit = angles.eulerAngles;

        //Quaternion.Euler(0.0f, state.ThumbSticks.Left.X * 25.0f * Time.deltaTime, 0.0f);

        //Debug.Log(whateveryouwanttocallit);
        //Debug.Log(Quaternion.Euler(0.0f, state.ThumbSticks.Left.X * 25.0f * Time.deltaTime, 0.0f));
        //Vector2 rightStick = new Vector2(state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y);
        //float angle2 = Vector3.Angle(new Vector3(0.0f, 1.0f, 0.0f), new Vector3(state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y, 0.0f));
        //if (state.ThumbSticks.Right.X < 0.0f)
        //{
        //    Debug.Log("IN THIS BITCH");
        //    angle2 = 360 - angle2;
        //}
        //Debug.Log(angle2);
        //Debug.Log(state.ThumbSticks.Right.X);
        //Debug.Log(state.ThumbSticks.Right.Y);
        //if (rightStick.magnitude > 0.5)
        //{
        //    rigidBodyAttachedToPlayerInGameObject.rotation = angle2;
        //}
    }

    //void OnGUI()
    //{
    //    string text = "Use left stick to turn the cube, hold A to change color\n";
    //    text += string.Format("IsConnected {0} Packet #{1}\n", state.IsConnected, state.PacketNumber);
    //    text += string.Format("\tTriggers {0} {1}\n", state.Triggers.Left, state.Triggers.Right);
    //    text += string.Format("\tD-Pad {0} {1} {2} {3}\n", state.DPad.Up, state.DPad.Right, state.DPad.Down, state.DPad.Left);
    //    text += string.Format("\tButtons Start {0} Back {1} Guide {2}\n", state.Buttons.Start, state.Buttons.Back, state.Buttons.Guide);
    //    text += string.Format("\tButtons LeftStick {0} RightStick {1} LeftShoulder {2} RightShoulder {3}\n", state.Buttons.LeftStick, state.Buttons.RightStick, state.Buttons.LeftShoulder, state.Buttons.RightShoulder);
    //    text += string.Format("\tButtons A {0} B {1} X {2} Y {3}\n", state.Buttons.A, state.Buttons.B, state.Buttons.X, state.Buttons.Y);
    //    text += string.Format("\tSticks Left {0} {1} Right {2} {3}\n", state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y, state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y);
    //    GUI.Label(new Rect(0, 0, Screen.width, Screen.height), text);
    //}
}
