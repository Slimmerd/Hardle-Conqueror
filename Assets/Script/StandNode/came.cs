using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class came : MonoBehaviour
{
    public float OffsetX;
    public float OffsetY;
    public float OffsetZ;
    
    
    private CameraContainer _camcont;
    public Transform player;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Caveman")
        {
            _camcont = CamContainer.Caveman;
        }
        else if (SceneManager.GetActiveScene().name == "Mystical Forest")
        {
            _camcont = CamContainer.MysticalForest;
        } else if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            _camcont = CamContainer.SampleScene;
          
        }
    }

    private void FixedUpdate()
    {
        OffsetX = _camcont.OffsetX;
        OffsetY = _camcont.OffsetY;
        OffsetZ = _camcont.OffsetZ;
    }


    void Update () 
    {
        transform.position = new Vector3 (player.position.x+_camcont.OffsetX, _camcont.OffsetY, _camcont.OffsetZ); // Camera follows the player but 6 to the right
    }
}


