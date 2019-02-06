using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    float platformSpawnTime = 1f; //in secs
    float timer=0;

    public float decayTime = 15;

    public float spawnDistance = 1;
    public float spawnRange = 2;
    private float lastPlatform = 0;

    private float rand = 0;

    public GameObject platform;

    float score;

    private void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<GameManager>().score;
    }

    void Update()
    {
        if (lastPlatform + spawnDistance + rand <= score)
        {

            spawn(Mathf.FloorToInt( Random.Range(1, 4)), platform);

            lastPlatform = score;
            rand = Random.Range(-(spawnRange/2), (spawnRange/2));
        }
    }

    void spawn( int n, GameObject objToSpawn)
    {
        for(int i=0; i<n; i++)
        {
            GameObject go = Instantiate(objToSpawn, new Vector3(Random.Range(-3f, 3), transform.position.y, 0), Quaternion.identity);
            Destroy(go, decayTime);
        }
    }
}
