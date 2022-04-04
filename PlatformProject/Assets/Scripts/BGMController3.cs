using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController3 : MonoBehaviour
{
    public static BGMController3 instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().name == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
