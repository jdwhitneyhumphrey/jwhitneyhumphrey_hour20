using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextureScroller ground;
    public float gameTime = 10;

    float totalTimeElapsed = 0;
    bool isGameOver = false;

    void Update()
    {
        if (isGameOver)
            return;

        totalTimeElapsed += Time.deltaTime;
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
            isGameOver = true;
    }

    public void AdjustTime(float amount)
    {
        gameTime += amount;
        if (amount < 0)
            SlowWorldDown();
    }

    void SlowWorldDown()
    {
        //Cancel any invokes to speed the world up
        //Then slow the world down for 1 second
        CancelInvoke();
        Time.timeScale = 0.5f;
        invoke("SpeedWorldUp", 1);
    }

    void SpeedWorldUp()
    {
        Time.timeScale = 1f;
    }
    //Note this is using the Unity's legacy GUI system
    void OnGUI()

    {
        if (isGameOver)
        {
            Rect boxRect = new Rect(Screen.width / 2 - 50, Screen.Height - 100, 100, 50);
            OnGUI.Box(boxRect, "Time Remaining");

            Rect labelRect = new Rect(Screen.width / 2 - 10, Screen.height / 2 - 80, 90, 40);
            OnGUI().Label(labelRect. ((int)gameTime).ToString());
        }

        else
        {
            Rect boxRect = new Rect(Screen.width / 2 - 60, Screen.height / 2 - 100, 120, 50);
            OnGUI.Box(boxRect, "Game Over");
            Rect labelRect = new Rect(Screen.width / 2 - 55, Screen.height / 2 - 80, 90, 40);
            GUI.Label(labelRect, "Total Time: " + (int)totalTimeElapsed);

            Time.timeScale = 0;
        }
    }
}
