using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerGeneration : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public float time;
    public float timestampTime;
    public Text countdownText;
    public RoomGeneration roomGeneration;
    public int increaseDifficultyInterval;

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

        if (timestampTime+increaseDifficultyInterval < time)
        {
            timestampTime = time;
            if(roomGeneration.chanceToSpawn >= 0.5 || roomGeneration.roomSegmentSize >= 16)
            roomGeneration.chanceToSpawn -= 0.05;
            roomGeneration.roomSegmentSize += 0.5f;
        }

        if(time == 30)
        {
            roomGeneration.difficulty = 2;
        }else if(time == 60)
        {
            roomGeneration.difficulty = 3;
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

