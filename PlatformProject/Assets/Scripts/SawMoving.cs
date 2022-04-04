using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMoving : MonoBehaviour
{
    public float speed;
    public int startingPoint;

    public bool startTrigger = false;

    public Transform[] points;
    private int i;

    public static SawMoving instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        transform.position = points[startingPoint].position;
    }

    private void Update()
    {
        if (startTrigger && !GameManager.instance.isGameEnded)
        {
            if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
            {
                i++;
                if (i == points.Length)
                {
                    i = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
        
    }
}
