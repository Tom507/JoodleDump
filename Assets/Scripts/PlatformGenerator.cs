using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    float platformSpawnTime = 1f; //in secs
    float timer=0;

    public float decayTime = 15;

    public float spawnDistance = 1;
    public float lastPlatform = 0;

    private float rand = 0;

    public GameObject platform;
    
    void Update()
    {
        if (lastPlatform + spawnDistance + rand <= GameManager.Score)
        {

            spawn(Mathf.FloorToInt( Random.Range(1, 4)));

            lastPlatform = GameManager.Score;
            rand = Random.Range(-0.5f, 0.5f);
        }
    }

    void spawn( int n)
    {
        for(int i=0; i<n; i++)
        {
            GameObject go = Instantiate(platform, new Vector3(Random.Range(-3f, 3), transform.position.y, 0), Quaternion.identity);
            Destroy(go, decayTime);
        }
    }
}
