using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoomCollider : MonoBehaviour
{
    public RoomGeneration roomGeneration;
    public BoxCollider collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            roomGeneration.FillRoom();
            collider.gameObject.SetActive(false);
        }
    }
}
