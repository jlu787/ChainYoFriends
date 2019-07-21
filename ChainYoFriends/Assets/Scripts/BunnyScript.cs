using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class BunnyScript : MonoBehaviour
{
    //public float circleDistance = 3.0f;
    //public float circleRadius = 1.0f;
    private Rigidbody2D rb;
    public float wanderForce = 2.0f;
    public float maxSpeed = 3.0f;
    SkeletonAnimation skeleton;
    float wanderTimer;
    float wanderSpeed;
    Vector2 wanderPoint;

    // Start is called before the first frame update
    void Start()
    {
        skeleton = GetComponentInChildren<SkeletonAnimation>();
        rb = GetComponent<Rigidbody2D>();
        wanderTimer = 0.0f;
        wanderSpeed = 1.0f;
    }

    private void FixedUpdate()
    {
        if (wanderTimer > 0.0f)
        {
            wanderTimer -= 1.0f;
        }
        else
        {
            wanderTimer = Random.Range(15.0f, 90.0f);
            wanderSpeed = Mathf.Clamp(Random.Range(-3.0f, 4.0f), 0.0f, 1.0f);
            if (wanderSpeed < 0.1f)
            {
                rb.velocity = rb.velocity.normalized * 0.1f;
                skeleton.AnimationName = "Idle";
            }
            else
            {
                skeleton.AnimationName = "Hopping";
            }

            float distance = Vector3.Distance(transform.position, new Vector3(0.0f,0.0f,0.0f));

            if (distance < 4.0f)
            {
                wanderPoint = Random.insideUnitCircle.normalized * wanderForce;
            }
            else
            {
                wanderPoint = transform.position * -wanderForce;               
            }
        }

        rb.AddForce(wanderPoint * wanderSpeed);

        if(rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed / 2;
        }

        Vector2 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector2 currentVelocity = rb.velocity;
        //currentVelocity.Normalize();
        //Vector2 circleCentre = currentVelocity * circleDistance;
        
    }
}
