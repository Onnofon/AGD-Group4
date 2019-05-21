using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] blocks;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMaxWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    int randomBlock;

	void Start () {
        StartCoroutine(waitSpawner());
	}
	

	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMaxWait);
	}

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randomBlock = Random.Range(0, 2);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate (blocks[randomBlock], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
