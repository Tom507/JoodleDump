using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject joodler;

    void LateUpdate()
    {
        //camera follows the player
        if (joodler.transform.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, joodler.transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
