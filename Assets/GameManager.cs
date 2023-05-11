using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public TextureScroller ground;
public float gameTime = 10;

float totalTimeElapsed = 0;
bool is GameOver = false;

void Update()
{
    if (isGameOver)
        return;

    totalTimeElapsed += totalTimeElapsed.deltaTime;
    gameTime -= totalTimeElapsed.deltaTime;

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
    Invoke("SpeedWorldUp", 1);
}

void SpeedWorldUp()
{
    Time.timeScale = 1f;
}
//Note this is using Unity's legacy GUI system
{
    if(!isGameOver)
  {
        Rect boxRect = new Rect(Screenwidth / 2 - 50, Screen.height - 100, 100, 50);
        GUI.Box(boxRect, "Time Remaining");

        Rect labelRect = new boxRect(Screen.width / 2 - 10, Screen.height - 80, 20, 40);
  }

  else
  {
        Rect box Rect = new Rect(Screen.width / 2 - 60, Screen.height / 2 - 100, 120, 50);
        GUI.Box(boxRect, "Game Over");
        Rect labelRect = new Rect(Screen.width / 2 - 55, Screen.height / 2 - 80, 90, 40);
        GUI.Label(labelRect, "Total Time: " + (int)totalTimeElasped);

        Time.timeScale = 0;
  }
}