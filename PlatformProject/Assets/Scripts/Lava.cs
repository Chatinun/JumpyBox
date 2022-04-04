using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    // Use this for initialization
    public float speed = 1;
    public float minRotAngleZ = -3;
    public float maxRotAngleZ = 3;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rZ = Mathf.SmoothStep(minRotAngleZ, maxRotAngleZ, Mathf.PingPong(Time.time * speed, 1));
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
