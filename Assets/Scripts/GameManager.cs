using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text scoreText;
    public int targets;
    public float maxTime = 5f;
    public Text countdownText;
    public GameObject timeup;
    public GameObject win;
    public AudioSource point;

    void Start ()
    {
        UpdateScore();
        win.SetActive(false);
        timeup.SetActive(false);
        StartCoroutine("LoseTime");
    }
    //countdown + lose conditions
    void Update()
    {
        countdownText.text = ("Time Left = " + maxTime);

        if (maxTime <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = " ";
            timeup.SetActive(true);
        }

        if (maxTime > 0 && targets == 0)
        {
            win.SetActive(true);
            StopCoroutine("LoseTime");
        }
    }
    //Countdowntimer
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            maxTime--;
        }
    }
    //targets updater
    public void TargetScore (int newTargetValue)
    {
        targets += newTargetValue;
        point.Play();
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Targets left: " + targets;
    }
}
