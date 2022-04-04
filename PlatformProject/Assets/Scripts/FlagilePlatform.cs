using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagilePlatform : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D col;
    private Rigidbody2D rb;

    private bool destroyed;

    private Vector3 originPosition;
    [SerializeField] private float destroyTime;
    [SerializeField] private float respawnTime;
    [SerializeField] private float shakeAmount;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (destroyed)
        {
            gameObject.transform.position = originPosition + UnityEngine.Random.insideUnitSphere * shakeAmount;
        }
        
    }

    private void Start()
    {
        originPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Break());
            destroyed = true;
        }
        if(collision.gameObject.tag == "Ground")
        {
            col.enabled = false;
        }
    }

    IEnumerator Break()
    {
        yield return new WaitForSeconds(destroyTime);
        rb.bodyType = RigidbodyType2D.Dynamic;
        //col.enabled = false;
        destroyed = false;
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        rb.bodyType = RigidbodyType2D.Static;
        col.enabled = true;
        transform.position = originPosition;
    }

}
