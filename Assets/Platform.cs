using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        //removes the platform
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        transform.position += Vector3.down * Time.deltaTime * speed;
    }
}
