using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    float platformSpawnTime = 1f; //in secs
    float timer=0;

    public GameObject platform;
    
    void Update()
    {

        //creates a platform each platformSpawnTime-seconds
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Instantiate(platform, new Vector3(Random.Range(-3f, 3), transform.position.y), Quaternion.identity);

            timer = platformSpawnTime;
        }
    }
}
