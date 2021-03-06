﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    public float decayTime = 0;

    public float spawnDistance = 1;
    public float spawnRange = 2;

    public int spawnamount = 2;

    private float lastSpawn = 0;
    private float rand = 0;

    public List<GameObject> spawnObjects = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (lastSpawn + spawnDistance + rand <= GameManager.Score && spawnObjects.Count > 0)
        {

            spawn(Mathf.FloorToInt(Random.Range(1, spawnamount + 1)), spawnObjects[Mathf.FloorToInt( Random.Range(0, spawnObjects.Count))], decayTime);

            lastSpawn = GameManager.Score;
            rand = Random.Range(-(spawnRange / 2), (spawnRange / 2));
        }
    }

    void spawn(int amount, GameObject objToSpawn, float decayTime)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject go = Instantiate(objToSpawn, new Vector3(Random.Range(-3f, 3), transform.position.y, 0), Quaternion.identity);
            Destroy(go, decayTime);
        }
    }
}
