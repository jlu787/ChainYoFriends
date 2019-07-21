using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawMovementScript : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        gameObject.GetComponent<Rigidbody2D>().velocity = (pos2 - pos1).normalized * speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
