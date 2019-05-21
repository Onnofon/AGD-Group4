using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
         if(col.gameObject.tag == "Despawner")
        {
            Destroy(gameObject);
        }
    }
}
