using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject cam;
    public GameObject joodler;

    void Update()
    {
        //end game if player falls
        if (joodler.transform.position.y + 6 < cam.transform.position.y)
        {

            endGame();

        }
    }

    public void endGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}