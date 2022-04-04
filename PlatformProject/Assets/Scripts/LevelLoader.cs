using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    [SerializeField] private Animator transitionAnimator;
    [SerializeField] float transitionTime = 1f;

    private void Awake()
    {
        instance = this;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadNextLevelTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadNextLevelTransition(int levelIndex)
    {
        transitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        PlayerPrefs.SetInt("SavedLevel", SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadSavedLevel(int levelName)
    {
        StartCoroutine(LoadSavedLevelTransition(levelName));
    }

    IEnumerator LoadSavedLevelTransition(int levelName)
    {
        transitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadMainMenuTransition());
    }

    IEnumerator LoadMainMenuTransition()
    {
        transitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(0);
    }

}
