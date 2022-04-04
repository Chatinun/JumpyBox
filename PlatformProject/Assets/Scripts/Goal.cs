using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject keyMissingMessage;
    private bool showMessage;
    private void Awake()
    {
        keyMissingMessage = gameObject.transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        if (showMessage)
        {
            keyMissingMessage.SetActive(true);
        }
        else
        {
            keyMissingMessage.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (GameManager.instance.key >= GameManager.instance.maxKey) //Collect all the key
            {
                Debug.Log("Yay! I love you");
                AudioManager.instance.audioPlay("LevelComplete");
                GameManager.instance.GameEnded();
                GameManager.instance.TimerAddToTotal();
            }
            else
            {
                Debug.Log("You need to collect all the key first!");
                AudioManager.instance.audioPlay("MissingKey");
                showMessage = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            showMessage = false;
        }
    }
}
