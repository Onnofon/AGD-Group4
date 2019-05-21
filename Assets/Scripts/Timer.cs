using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{

    Image timer;
    public float maxTime = 5f;
    float timeLeft;
    public Text countdownText;
    public GameObject timeup;

    void Start()
    {
        timeup.SetActive(false);
        StartCoroutine("LoseTime");
    }


    void Update()
    {
        countdownText.text = ("Time Left = " + maxTime);

        if (maxTime <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = " ";
            timeup.SetActive(true);
        }
    }
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            maxTime--;
        }
    }
}