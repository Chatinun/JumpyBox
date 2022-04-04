using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpy : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D col;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController.instance.doubleJump = true;
            sr.enabled = false;
            col.enabled = false;
            StartCoroutine(delayRespawn());
            AudioManager.instance.audioPlay("JumpToken");
        }

    }

    IEnumerator delayRespawn()
    {
        yield return new WaitForSeconds(3);
        sr.enabled = true;
        col.enabled = true;
    }
}
