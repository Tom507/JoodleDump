using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject cam;
    public GameObject joodler;

    public float score = 0;

    Animator camAnim;

    bool gameEnded = false;

    public RectTransform restartBtn;
    public RectTransform pauseBtn;
    public RectTransform continueBtn;
    public Text scoreText;
   

    private void Start()
    {
        joodler.transform.Find("ShootingPoint").GetComponent<JoodlerShooting>().enabled = false;
        Time.timeScale = 0;

        camAnim = Camera.main.GetComponent<Animator>();
    }

    public void continueGame()
    {
        joodler.transform.Find("ShootingPoint").GetComponent<JoodlerShooting>().enabled = true;

        pauseBtn.gameObject.SetActive(true);
        continueBtn.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    public void stopGame()
    {
        joodler.transform.Find("ShootingPoint").GetComponent<JoodlerShooting>().enabled = false;

        pauseBtn.gameObject.SetActive(false);
        continueBtn.gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    public void disableThisButton(RectTransform btn)
    {
        btn.gameObject.SetActive(false);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    void Update()
    {
        if (!gameEnded)
        {
            if (joodler.transform.position.y > score)
                score = joodler.transform.position.y;


            //end game if player falls
            if (joodler.transform.position.y + 6 < cam.transform.position.y)
            {

                endGame();
                score = 0;
            }
        }
        
    }

    public void endGame()
    {
        gameEnded = true;

        joodler.GetComponent<JoodlerMovement>().enabled = false;
        joodler.GetComponent<BoxCollider2D>().enabled = false;
        joodler.transform.Find("ShootingPoint").GetComponent<JoodlerShooting>().enabled = false;
        Camera.main.GetComponent<FollowPlayer>().enabled = false;
        Destroy(joodler, 2f);

        restartBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);

        scoreText.text = "Score: "+(int)(score);

    }
}