using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private Animator jumppadAnim;
    [SerializeField] private Animator lightAnim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController.instance.rb.velocity = Vector2.up * 15;
            jumppadAnim.SetTrigger("Bounce");
            lightAnim.SetTrigger("Bounce");
            AudioManager.instance.audioPlay("Bounce");
        }
    }
}
