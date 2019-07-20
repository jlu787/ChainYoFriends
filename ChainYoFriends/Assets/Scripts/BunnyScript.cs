using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyScript : MonoBehaviour
{
    //public float circleDistance = 3.0f;
    //public float circleRadius = 1.0f;
    public Rigidbody2D rb;
    public float wanderForce = 3.0f;
    public float maxSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(Random.insideUnitCircle.normalized * wanderForce);
        if(rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector2 currentVelocity = rb.velocity;
        //currentVelocity.Normalize();
        //Vector2 circleCentre = currentVelocity * circleDistance;
        
    }
}
