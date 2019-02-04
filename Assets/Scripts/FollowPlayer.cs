using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject joodler;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (joodler.transform.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, joodler.transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
