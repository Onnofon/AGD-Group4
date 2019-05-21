using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemover : MonoBehaviour
{

    private void Start()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "Target")
        {
            Destroy(gameObject);
        }
    }
}
