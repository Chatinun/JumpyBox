using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    private Vector3 originPos;

    private Rigidbody2D rb;

    [SerializeField] private float delayTime = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        originPos = gameObject.transform.position;
        StartCoroutine(StartFalling());
    }
    
    IEnumerator StartFalling()
    {
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(FallingLoop());
    }

    IEnumerator FallingLoop()
    {
        yield return new WaitForSeconds(2);
        gameObject.transform.position = originPos;
        rb.velocity = Vector2.zero;
        StartCoroutine(FallingLoop());
    }
}
