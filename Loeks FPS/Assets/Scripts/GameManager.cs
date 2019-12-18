using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;

    public bool gamePaused;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            TogglePauseGame();
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked; 

        //toggle pause menu
        GameUI.instance.TogglePauseMenu(gamePaused);
    }

    public void AddScore(int score)
    {
        curScore += score;

        GameUI.instance.UpdateScoreText(curScore);
        if (curScore >= scoreToWin)
            WinGame();
    }

    void WinGame()
    {
        GameUI.instance.SetEndGameScreen(true, curScore);

        Time.timeScale = 0.0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoseGame()
    {
        GameUI.instance.SetEndGameScreen(false, curScore);

        Time.timeScale = 0.0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None; 
    }
}
