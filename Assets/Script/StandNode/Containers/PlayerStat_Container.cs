using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat
{
    public float jumpHeight; //We can set the jump height in Unity
    public float JumpMax;
    public float PlayerHeightY;
    public float PlayerHeightX;
    public float PlayerSquatSize;
    public float PlayerSpeed;
    public float PlayerMinSquat;

    public PlayerStat(float jumpHeight, float JumpMax, float PlayerHeightY, float PlayerHeightX, float PlayerSquatSize,
        float PlayerSpeed,
        float PlayerMinSquat)
    {
        this.jumpHeight = jumpHeight;
        this.JumpMax = JumpMax;
        this.PlayerHeightY = PlayerHeightY;
        this.PlayerHeightX = PlayerHeightX;
        this.PlayerSquatSize = PlayerSquatSize;
        this.PlayerSpeed = PlayerSpeed;
        this.PlayerMinSquat = PlayerMinSquat;
    }
}


public static class PlayerStatContainer
{
    public static readonly PlayerStat Caveman = new PlayerStat(
        23,
        -4.5f,
        0.6f,
        0.6f,
        0.4f,
        6f,
        -3);

    public static readonly PlayerStat MysticalForest = new PlayerStat(
        27,
        -4.5f,
        0.8f,
        0.8f,
        0.4f,
        6f,
        -3);

    public static readonly PlayerStat SampleScene = new PlayerStat(
        22,
        4, 
        1, 
        1,
        0.5f,
        6f, 
        4);
}