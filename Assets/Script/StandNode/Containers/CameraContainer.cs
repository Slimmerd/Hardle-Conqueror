using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContainer
{
    public float OffsetX;
    public float OffsetY;
    public float OffsetZ;


    public CameraContainer(float offsetX, float offsetY, float offsetZ)
    {
        this.OffsetX = offsetX;
        this.OffsetY = offsetY;
        this.OffsetZ = offsetZ;
    }
}

public static class CamContainer
{
    public static readonly CameraContainer Caveman = new CameraContainer(4.47f,-0.33f,-2);
    public static readonly CameraContainer MysticalForest = new CameraContainer(4.47f,-0.33f,-2);
    public static readonly CameraContainer SampleScene = new CameraContainer(4.47f,6,-2);
}