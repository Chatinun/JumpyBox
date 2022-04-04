using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{
    public static BGMController instance;
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
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(gameObject);
        }
        else if (SceneManager.GetActiveScene().name == "Lv3")
        {
            Destroy(gameObject);
        }
    }
}
