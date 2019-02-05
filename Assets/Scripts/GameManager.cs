using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject cam;
    public GameObject joodler;

    public static float Score = 0;

    Animator camAnim;

    private void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();
    }

    void Update()
    {
        if(joodler.transform.position.y > Score)
            Score = joodler.transform.position.y;


        //end game if player falls
        if (joodler.transform.position.y + 6 < cam.transform.position.y)
        {

            endGame();
            Score = 0;
        }
    }

    public void endGame()
    {
        /*
        joodler.GetComponent<JoodlerMovement>().enabled = false;
        joodler.GetComponent<BoxCollider2D>().enabled = false;
        joodler.transform.Find("ShootingPoint").GetComponent<JoodlerShooting>().enabled = false;

        camAnim.SetBool("EndGame", true);
        */

        SceneManager.LoadScene("MainScene");
    }
}