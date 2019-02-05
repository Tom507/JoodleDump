using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDecorations : MonoBehaviour
{
    float decoSpawnTime = 3f; //in secs
    float timer = 0;

    public GameObject deco;
    public Sprite[] sprites;
    

    void Update()
    {

        //creates a deco each decoSpawnTime-seconds
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            var d = Instantiate(deco, new Vector3(Random.Range(-10f, 10f), transform.position.y, Random.Range(10, 20)), Quaternion.identity);

            d.transform.Rotate(new Vector3(0,0,Random.Range(0,360)));

            d.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

            float size = Random.Range(1f, 3f);
            d.transform.localScale = new Vector3(size, size);

            Destroy(d, 25);

            timer = decoSpawnTime;
        }
    }
}
