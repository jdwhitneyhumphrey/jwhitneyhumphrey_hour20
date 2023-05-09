using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public TextureScroller ground;
public float gameTime = 10;

float totalTimeElapsed = 0;
bool isGameOver = flase;

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
    if (amount <= 0)
        SlowWorldDown();
}

void SlowWorldDown()
{
    //cancel any invokes to speed the world up
    //then slow the world down for 1 second
    CancelInvoke();
    Time.timeScale = 0.5f;
    invoke("SpeedWorldUp", 1);
}

void SpeedWorldUp()
{
    Time.timeScale = 1f;
}