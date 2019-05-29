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
    public GameObject spawnRoom;
    private int nextZPosition = -224;
    private int nextZSpawnRoom = -14;
    public Vector3 roomSize;
    
    public int amountOfObjects;
    public GameObject target;
    public int amountOfTargets;
    public float roomSegmentSize;
    public double chanceToSpawn;
    private int RandomValue;
    private Vector3 spawnCoord;
    private Vector3 origin;
    private Vector3 range;
    private Vector3 randomCoordinate;
    private Vector3 randomRange;

    public void FillRoom()
    {
        if (difficulty == 1)
        {
            toSpawnArray = difficulty1;
        }
        else if (difficulty == 2)
        {
            toSpawnArray = difficulty2;
        }
        else
        {
            toSpawnArray = difficulty3;
        }

        origin = spawnRoom.transform.position;
        range = spawnRoom.transform.localScale / 2.0f;
        spawnCoord = new Vector3(-range.x, -range.y, -range.z);
        target = Instantiate(target, spawnCoord, target.transform.rotation);
        for (float z = 0; z <= spawnRoom.transform.localScale.z; z += roomSegmentSize)
        {
            for (float y = 0; y <= spawnRoom.transform.localScale.y; y += roomSegmentSize)
            {
                for (float x = 0; x <= spawnRoom.transform.localScale.x; x += roomSegmentSize)
                {
                    RandomValue = Random.Range(0, 10);
                    spawnCoord = new Vector3(-range.x + x, -range.y + y + RandomValue, -range.z + z + nextZSpawnRoom);
                    int arrayRange = Random.Range(0, toSpawnArray.Length);
                    GameObject toSpawn = toSpawnArray[arrayRange];
                    if (Random.value <= chanceToSpawn)
                    {
                        toSpawn = Instantiate(toSpawn, spawnCoord, toSpawn.transform.rotation);
                    }
                }
            }
        }

        for (int i = 0; i < amountOfTargets; i++)
        {
            randomRange = new Vector3(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y), Random.Range(-range.z, range.z));
            randomCoordinate = origin + randomRange;
            target = Instantiate(target, randomCoordinate, target.transform.rotation);
        }
    }

    public void MovePipeLine()
    {
        spawnroomCol.collider.gameObject.SetActive(true);
        Debug.Log("Move Pipeline");
        nextZPosition += 70;
        nextZSpawnRoom += 70;
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
        Gizmos.DrawWireCube(spawnRoom.transform.position, roomSize);
    }
}
