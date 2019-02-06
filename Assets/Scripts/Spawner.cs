using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float decayTime = 0;

    public float spawnDistance = 1;
    public float randomDistance = 2;

    public float spawnRangeX = 3;

    public int spawnAmount = 2;
    public bool randomAmount = false;

    private float lastSpawn = 0;
    private float rand = 0;

    public List<GameObject> spawnObjects = new List<GameObject>();

    float score;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("GameManager").GetComponent<GameManager>().score;

        if (lastSpawn + spawnDistance + rand <= score && spawnObjects.Count > 0)
        {
            var amount = spawnAmount;

            if (randomAmount)
                amount = Random.Range(1, spawnAmount + 1);

            spawn(Mathf.FloorToInt(amount), spawnObjects[Mathf.FloorToInt(Random.Range(0, spawnObjects.Count))], decayTime);

            lastSpawn = score;
            rand = Random.Range(-(randomDistance / 2), (randomDistance / 2));
        }
    }

    void spawn(int amount, GameObject objToSpawn, float decayTime)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject go = Instantiate(objToSpawn, new Vector3(Random.Range(-spawnRangeX, spawnRangeX), transform.position.y, 0), Quaternion.identity);
            Destroy(go, decayTime);
        }
    }
}
