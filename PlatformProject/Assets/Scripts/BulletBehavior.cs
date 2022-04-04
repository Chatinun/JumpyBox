using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float direction;
    [SerializeField] private float bulletSpeed;

    [SerializeField] private GameObject explosiveEffect;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //rb.velocity = -transform.right * bulletSpeed;
        transform.localRotation = new Quaternion(0, 0, 90,0);
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + bulletSpeed * direction * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            Instantiate(explosiveEffect, transform.position, Quaternion.identity);
        }
    }
}
