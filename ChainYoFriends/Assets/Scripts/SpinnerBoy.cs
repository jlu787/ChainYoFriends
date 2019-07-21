using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerBoy : MonoBehaviour
{
    public float revspeed = 10f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, revspeed * Time.deltaTime);
    }
}
