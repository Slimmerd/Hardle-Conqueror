using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyHand : MonoBehaviour
{
    // public int rotationOffset = 90;
    public Transform player;
    private bool adead;
    private bool faceRight;

    private void Update()
    {
        Enemy enemy = GetComponentInParent<Enemy>();
        faceRight = enemy.m_FacingRight;
        adead = enemy._edead;

        if (player != null && adead == false)
        {
            Vector3 difference = player.position - transform.position;
            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            if (faceRight == true)
            {
                transform.rotation = Quaternion.Euler(0, 0f, rotZ + 88);
            }

            if (faceRight == false)
            {
                transform.rotation = Quaternion.Euler(-180, 0f, -rotZ + 88);
            }
        }

        if (MoveContrl.Pdead == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}