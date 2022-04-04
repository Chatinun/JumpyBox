using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float bouncingForce;
    [SerializeField] private float startDelay;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(DelayBouncing());
    }
    IEnumerator DelayBouncing()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(Bounce());
    }
    IEnumerator Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, bouncingForce);
        yield return new WaitForSeconds(3);
        StartCoroutine(Bounce());
    }
}
