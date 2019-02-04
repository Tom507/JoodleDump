using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void changeScene(string scene)
    {
        //start game
        SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        //leave game
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
