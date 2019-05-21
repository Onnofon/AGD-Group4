using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject[] difficulty1;
    public GameObject[] difficulty2;
    public GameObject[] difficulty3;

    public SpawnRoomCollider spawnroomCol;
    public GameObject pipeline;
    public GameObject toBeDeletedRoom;
    public GameObject oldRoom;
    public GameObject nextRoomCollider;
    public GameObject SpawnRoom;
    private int nextZPosition = -224;
    public Vector3 roomSize;

    public void FillRoom()
    {
        Vector3 origin = SpawnRoom.transform.position;
        Vector3 range = SpawnRoom.transform.localScale / 2.0f;
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                      Random.Range(-range.y, range.y),
                                      Random.Range(-range.z, range.z));
            Vector3 randomCoordinate = origin + randomRange;
            int arrayRange = Random.Range(0, difficulty1.Length);
            Debug.Log(arrayRange);
            GameObject toSpawn = difficulty1[arrayRange];
            toSpawn = Instantiate(toSpawn, randomCoordinate, toSpawn.transform.rotation);
        }
        Debug.Log("Fill Room");
    }

    public void MovePipeLine()
    {
        spawnroomCol.collider.gameObject.SetActive(true);
        Debug.Log("Move Pipeline");
        nextZPosition += 70;
        pipeline.transform.position = new Vector3(0, 0, nextZPosition);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(toBeDeletedRoom.transform.position, roomSize);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(oldRoom.transform.position, roomSize);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(nextRoomCollider.transform.position, roomSize);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(SpawnRoom.transform.position, roomSize);
    }
}
