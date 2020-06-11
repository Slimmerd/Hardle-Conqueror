using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    public int rotationOffset = 90;
    public static int m_Right = 0;
    public static int m_Down = 0;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (rotZ >= -100 && rotZ <= -70)
        {
            m_Down = 1;
        }
        else
        {
            m_Down = 0;
        }

        if (rotZ >= -90 && rotZ <= 90)
        {
            m_Right = 1;
        }
        else
        {
            m_Right = -1;
        }


        if (MoveContrl.m_FacingRight == true && MenuPause.GamePaused == false) 
        {
            transform.rotation = Quaternion.Euler(0, 0, rotZ + rotationOffset);
        }

        if (MoveContrl.m_FacingRight == false && MenuPause.GamePaused == false)
        {
            transform.rotation = Quaternion.Euler(180, 0, -rotZ + rotationOffset);
        }
    }
}