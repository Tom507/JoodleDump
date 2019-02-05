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
            var d = Instantiate(deco, new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, 10), Quaternion.identity);

            d.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

            float size = Random.Range(.2f, 1.5f);
            d.transform.localScale = new Vector3(size, size);

            Destroy(d, 10);

            timer = decoSpawnTime;
        }
    }
}
