using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels to Load")]
    public string newGameLevel;
    private int levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    private void Start()
    {
        //PlayerPrefs.DeleteKey("SavedLevel");
    }

    public void NewGameDialogYes()
    {
        LevelLoader.instance.LoadNextLevel();
        PlayerPrefs.DeleteKey("TotalTimer");
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetInt("SavedLevel");
            //PlayerPrefs.SetString("SavedLevel", "x");
            //SceneManager.LoadScene(levelToLoad);
            LevelLoader.instance.LoadSavedLevel(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
