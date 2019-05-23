using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerGeneration : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public float time;
    public Text countdownText;
    public RoomGeneration roomGeneration;

    private void Start()
    {
        UpdateScore(0);
        time = 0;
        StartCoroutine(UpTime());
    }

    //countdown + lose conditions
    void Update()
    {
        countdownText.text = ("Time: " + time);

        if (time > 30)
        {
            roomGeneration.difficulty = 2;
        }
    }
    //Countdowntimer
    IEnumerator UpTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
    }
    //targets updater

    public void UpdateScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score: " + score;
    }
}

