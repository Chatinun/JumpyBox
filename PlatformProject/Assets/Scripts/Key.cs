using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Key : MonoBehaviour
{
    private CircleCollider2D col;
    private SpriteRenderer sr;

    private Light2D lt;
    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        lt = GetComponentInChildren<Light2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            col.enabled = false;
            sr.enabled = false;
            lt.intensity = 0;
            GameManager.instance.key++;
            AudioManager.instance.audioPlay("Key");
        }
    }
}
