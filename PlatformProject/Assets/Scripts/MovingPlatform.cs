using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;

    public bool waitForTrigger;
    private bool startMoving;

    public Transform[] points;
    private int i;

    private void Start()
    {
        transform.position = points[startingPoint].position;
    }

    private void Update()
    {
        if (waitForTrigger)
        {
            if (startMoving)
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
            return;
        }
            
        else
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
        if (waitForTrigger)
        {
            startMoving = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
