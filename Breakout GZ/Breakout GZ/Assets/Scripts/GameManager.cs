using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static int playerScore = 0;
    public static int playerLives = 5;
    public static int brickCount = 140;

    public GUISkin layout;

    GameObject theBall;

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetGame()
    {
        playerScore = 0;
        playerLives = 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //OnGUI Function dispay the score and reset button functionality
    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width/2 -200 -15, 20, 200,100), "Score: " + playerScore);
        GUI.Label(new Rect(Screen.width / 2 + 100 + 12, 20, 200, 100), "Lives: " + playerLives);

        if (playerLives == 0)
        {
            Time.timeScale = 0;
            GUI.Label(new Rect(Screen.width / 2-100, 200, 2000, 1000), "You Lose!");

            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2, 120, 50), "RESTART"))
            {
                ResetGame();
            }
        }

        if (brickCount == 0 || brickCount<=0)
        {
            Time.timeScale = 0;
            GUI.Label(new Rect(Screen.width / 2-150, 200, 2000, 1000), "Level 1 Complete!");
            Time.timeScale = 0;
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2, 120, 50), "Play Again"))
            {
                ResetGame();
            }
        }

    }
}
