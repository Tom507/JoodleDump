using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoodlerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float jumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //tilting
        transform.Translate(Input.acceleration.x, 0, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "platform" && rb.velocity.y < 0)
        {

            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }
    }

}
