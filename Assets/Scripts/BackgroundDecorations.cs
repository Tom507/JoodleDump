using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDecorations : MonoBehaviour
{
    float decoSpawnTime = 3f; //in secs
    float timer = 0;

    public GameObject deco;
    public Sprite[] sprites;

    public float spawnDistance = 10;
    public float randRange = 5;
    private float rand = 0;
    private float lastSpawn = 0;

    void Update()
    {

        if (lastSpawn + spawnDistance + rand <= GameManager.Score)
        {

            spawn(1);

            lastSpawn = GameManager.Score;
            rand = Random.Range(-(randRange/2), (randRange / 2));
        }


    }

    void spawn( int n)
    {
        for (int i = 0; i < n; i++)
        {
            var d = Instantiate(deco, new Vector3(Random.Range(-10f, 10f), transform.position.y, Random.Range(10, 20)), Quaternion.identity);

            d.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));

            d.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

            float size = Random.Range(1f, 3f);
            d.transform.localScale = new Vector3(size, size);

            Destroy(d, 25);
        }
    }
}
