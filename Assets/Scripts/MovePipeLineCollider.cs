using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipeLineCollider : MonoBehaviour
{
    public RoomGeneration roomGeneration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            roomGeneration.MovePipeLine();
        }
    }
}
