using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class movingObj : MonoBehaviour
{
    private float moveSpeed = 0.1f; //Moving Speed
    public Vector2 offset;
    public bool offsetY;


    public void Awake()
    {
        if (offsetY)
        {
            moveSpeed = 0.15f;
        }
    }

    // void Update()
    // {
    //     transform.position -= new Vector3(6f*Time.deltaTime,0,0);
    // }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
    
        moveSpeed += moveSpeed / 7500;
    
        if (transform.position.x <= -100)
        {
            transform.position = new Vector2(transform.position.x + 5f + Random.Range(offset.x, offset.y),
                transform.position.y); //Moving ground thing
            
            if (offsetY)
            {
                transform.position = new Vector2(transform.position.x, Random.Range(3f,6f));
            }
        }
    }
}