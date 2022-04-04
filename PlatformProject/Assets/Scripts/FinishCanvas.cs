using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalTimerText;

    private void Start()
    {
        float timer = PlayerPrefs.GetFloat("TotalTimer");
        int intTime = (int)timer;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = timer * 100;
        fraction = (fraction % 100);

        totalTimerText.text = System.String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }
}
