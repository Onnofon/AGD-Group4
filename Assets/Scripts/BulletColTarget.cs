using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColTarget : MonoBehaviour {
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
