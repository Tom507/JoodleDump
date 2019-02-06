using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoodlerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float jumpForce = 10f;

    Vector3 border;

    AudioSource audiosource;
    public AudioClip[] jumpSounds;

    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //flipping
#if UNITY_EDITOR
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
#elif UNITY_ANDROID
        if (Input.acceleration.x > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (Input.acceleration.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
#endif

        //tilting
#if UNITY_EDITOR

        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * 5 * Time.deltaTime;

#elif UNITY_ANDROID
        
        transform.Translate(Input.acceleration.x * .3f, 0, 0);

#endif
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //jumping
        if (other.gameObject.tag == "platform" && rb.velocity.y < 0)
        {

            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;

            anim.SetTrigger("jump");

            audiosource.clip = jumpSounds[Random.Range(0, jumpSounds.Length)];
            audiosource.Play();
        }

        //border teleport
        else if (other.gameObject.tag == "border")
        {
            float x;
            if (transform.position.x > 0)
            {
                x = .1f;
            }
            else
            {
                x = -.1f;
            }
            transform.position = new Vector3(-transform.position.x+x, transform.position.y);
        }
    }

}
