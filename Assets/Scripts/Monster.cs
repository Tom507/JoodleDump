using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    GameManager gm;

    public AudioClip deathSound;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            var bulletSound = other.GetComponent<AudioSource>();
            bulletSound.clip = deathSound;
            bulletSound.Play();
            Destroy(gameObject,2f);
            gameObject.SetActive(false);
        }
        else if (other.name == "Joodler")
        {
            gm.endGame();
        }
    }

}
