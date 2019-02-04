using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        //removes the platform
        Destroy(gameObject, 6);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
