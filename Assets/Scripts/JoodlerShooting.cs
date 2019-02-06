using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoodlerShooting : MonoBehaviour
{
    public SpriteRenderer[] feet;

    public GameObject footProjectile;

    float shootingCooldown = 1f; //in secs
    float shootingTimer = 0;

    float refillingCooldown = 3f;
    float refillingTimer = 0;

    AudioSource audiosource;
    public AudioClip[] shootSounds;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //shooting
        shootingTimer -= Time.deltaTime;

#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0) && !emptySlots())
        { 
            if (shootingTimer <= 0f)
            {
                Vector3 shootingDir = Input.mousePosition;
                shootingDir.z = 10;
                shootingDir = Camera.main.ScreenToWorldPoint(shootingDir);
                shootingDir = (shootingDir - transform.position).normalized;
                //Debug.DrawRay(transform.position, shootingDir, Color.red); //testing

                var f = Instantiate(footProjectile, transform.position, Quaternion.identity);

                Rigidbody2D fRigidbody = f.GetComponent<Rigidbody2D>();

                fRigidbody.AddForce(shootingDir * 500); //keep it this way, it does not work if you change 500 to a variable, dunno why

                fRigidbody.angularVelocity = 3;

                Destroy(f, 5);

                if (fullSlots())
                {
                    refillingTimer = refillingCooldown;
                }

                disableLeg();

                audiosource.clip = shootSounds[Random.Range(0, shootSounds.Length)];
                audiosource.Play();

                shootingTimer = shootingCooldown;
            }
        }

#elif UNITY_ANDROID

        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
        
            if (shootingTimer <= 0f && !emptySlots())
            {
                Vector3 shootingDir = myTouches[i].position;
                shootingDir.z = 10;
                shootingDir = Camera.main.ScreenToWorldPoint(shootingDir);
                shootingDir = (shootingDir - transform.position).normalized;
                //Debug.DrawRay(transform.position, shootingDir, Color.red); //testing

                var f = Instantiate(footProjectile, transform.position, Quaternion.identity);

                Rigidbody2D fRigidbody = f.GetComponent<Rigidbody2D>();

                fRigidbody.AddForce(shootingDir * 500); //keep it this way, it does not work if you change 500 to a variable, dunno why

                fRigidbody.angularVelocity = 3;

                Destroy(f, 5);

                if (fullSlots())
                {
                    refillingTimer = refillingCooldown;
                }

                disableLeg();

                audiosource.clip = jumpSounds[Random.Range(0, jumpSounds.Length)];
                audiosource.Play();
                
                shootingTimer = shootingCooldown;
            }

        }

#endif

        //refilling
        refillingTimer -= Time.deltaTime;
        if (refillingTimer <= 0f)
        {
            foreach (SpriteRenderer legSprite in feet)
            {
                if (!legSprite.enabled)
                {
                    legSprite.enabled = true;
                    refillingTimer = refillingCooldown;
                    break;
                }
            }
        }
    }

    bool emptySlots()
    {
        
        foreach (SpriteRenderer legSprite in feet)
        {
            if (legSprite.enabled)
            {
                return false;
            }
        }

        return true;
    }

    bool fullSlots()
    {
        foreach (SpriteRenderer legSprite in feet)
        {
            if (!legSprite.enabled)
            {
                return false;
            }
        }

        return true;
    }

    void disableLeg()
    {
        var leg = feet[Random.Range(0, feet.Length)];
        if (leg.enabled)
        {
            leg.enabled = false;
        }
        else
        {
            disableLeg();
        }
    }
}
