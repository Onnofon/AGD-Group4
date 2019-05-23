using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TargetCol : MonoBehaviour
{
    private GameManagerGeneration gameController;
    public int scoreValue;

    public void Start()
        {
            GameObject gameControllerObject = GameObject.FindWithTag("GameController");
            if (gameControllerObject != null)
            {
                gameController = gameControllerObject.GetComponent<GameManagerGeneration>();
            }

        }

        public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gameController.UpdateScore(3);
            Destroy(gameObject);
        }
    }
}
 