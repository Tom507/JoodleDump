using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject cam;
    public GameObject joodler;

    public static float Score = 0;

    void Update()
    {
        if(joodler.transform.position.y > Score)
            Score = joodler.transform.position.y;

        Debug.Log(Score);

        //end game if player falls
        if (joodler.transform.position.y + 6 < cam.transform.position.y)
        {

            endGame();
            Score = 0;
        }
    }

    public void endGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}