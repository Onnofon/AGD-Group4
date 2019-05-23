using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject[] difficulty1;
    public GameObject[] difficulty2;
    public GameObject[] difficulty3;
    private GameObject[] toSpawnArray;
    public int difficulty = 1;

    public GameManagerGeneration gameMangerGeneration;
    public SpawnRoomCollider spawnroomCol;
    public GameObject pipeline;
    public GameObject toBeDeletedRoom;
    public GameObject oldRoom;
    public GameObject nextRoomCollider;
    public GameObject SpawnRoom;
    private int nextZPosition = -224;
    public Vector3 roomSize;
    public int amountOfObjects;
    public GameObject target;

    private Vector3 origin;
    private Vector3 range;
    private Vector3 randomCoordinate;
    private Vector3 randomRange;

    public void FillRoom()
    {
        if(difficulty == 1)
        {
            toSpawnArray = difficulty1;
        }else if(difficulty == 2)
        {
            toSpawnArray = difficulty2;
        }
        else
        {
            toSpawnArray = difficulty3;
        }

        for (int i = 0; i < amountOfObjects; i++)
        {
            GetRandomPosition();
            int arrayRange = Random.Range(0, toSpawnArray.Length);
            GameObject toSpawn = toSpawnArray[arrayRange];
            toSpawn = Instantiate(toSpawn, randomCoordinate, toSpawn.transform.rotation);

            if(i == amountOfObjects -1)
            {
                GetRandomPosition();
                target = Instantiate(target, randomCoordinate, toSpawn.transform.rotation);
            }
        }
        Debug.Log("Fill Room");
    }

    public void GetRandomPosition()
    {
        origin = SpawnRoom.transform.position;
        range = SpawnRoom.transform.localScale / 2.0f;
        randomRange = new Vector3(Random.Range(-range.x, range.x),
                                      Random.Range(-range.y, range.y),
                                      Random.Range(-range.z, range.z));
        randomCoordinate = origin + randomRange;
    }

    public void MovePipeLine()
    {
        spawnroomCol.collider.gameObject.SetActive(true);
        Debug.Log("Move Pipeline");
        nextZPosition += 70;
        pipeline.transform.position = new Vector3(0, 0, nextZPosition);
        gameMangerGeneration.UpdateScore(1);
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
