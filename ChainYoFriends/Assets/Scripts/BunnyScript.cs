using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class BunnyScript : MonoBehaviour
{
    public BunnyHealth Health { get; set; } = BunnyHealth.Bunny;
    
    //public float circleDistance = 3.0f;
    //public float circleRadius = 1.0f;
    private Rigidbody2D rb;
    public float wanderForce = 2.0f;
    public float maxSpeed = 3.0f;
    private SkeletonAnimation skeleton;
    private float wanderTimer;
    private float wanderSpeed;
    private Vector2 wanderPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        skeleton = GetComponentInChildren<SkeletonAnimation>();
        rb = GetComponent<Rigidbody2D>();
        wanderTimer = 0.0f;
        wanderSpeed = 1.0f;
    }

    public void Hurt()
    {
        if (Health == BunnyHealth.DeadBunny)
        {
            Destroy(gameObject);
        }

        Health--;
        SetSkin();
    }

    public void Heal()
    {
        Health = BunnyHealth.Bunny;
        SetSkin();

    }

    private void SetSkin()
    {
        Skeleton skeleton = GetComponentInChildren<SkeletonAnimation>().skeleton;
        switch (Health)
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
