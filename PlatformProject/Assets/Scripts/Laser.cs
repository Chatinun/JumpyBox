using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private BoxCollider2D hitbox;
    private SpriteRenderer sr;

    [SerializeField] private float everyXSecond = 1f;
    [SerializeField] private float startDelay;
    private void Awake()
    {
        hitbox = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(Switching());
    }

    IEnumerator Switching()
    {
        ChangeState();
        yield return new WaitForSeconds(everyXSecond);
        StartCoroutine(Switching());
    }

    void ChangeState()
    {
        hitbox.enabled = !hitbox.enabled;
        if (hitbox.enabled)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
        }
        else
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
        }
        
    }
}
