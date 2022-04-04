using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBox : MonoBehaviour
{
    [SerializeField] private bool boxEnable = true;
    [SerializeField] private float everyXSecond = 1f;

    private SpriteRenderer sr;
    private BoxCollider2D col;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        InvokeRepeating("Loop", 0f, everyXSecond);
    }

    private void Update()
    {
        if (boxEnable)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
            col.enabled = true;
        }
        else
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            col.enabled = false;
        }
    }

    void Loop()
    {
        boxEnable = !boxEnable;
    }

}
