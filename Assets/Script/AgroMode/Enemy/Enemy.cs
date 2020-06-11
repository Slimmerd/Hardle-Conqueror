using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public float health = 100; //Enemy health
    public GameObject deathEffect;
    public BoxCollider2D[] boxcols;
    public bool m_FacingRight = true;
    private bool _pdead;
    public  bool _edead = false;
    private int _money;

    // Following script
    [Header("Stats")] public float walkSpeed;
    public float stoppingDistance;
    public float nearDistance;

    [Header("References")] public Transform player;

    //End of Following script
    void Start()
    {
        boxcols = GetComponentsInChildren<BoxCollider2D>();
        _edead = false;
        _pdead = MoveContrl.Pdead;
        m_FacingRight = true;

        foreach (BoxCollider2D rd in boxcols)
        {
            rd.GetComponent<Rigidbody2D>().isKinematic = true;
            rd.GetComponent<HingeJoint2D>().enabled = true;
        }
    }

    //Following script
    public void Update()
    {
        if (player != null && _edead == false)
        {
            if (Vector2.Distance(transform.position, player.position) < nearDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(player.position.x, transform.position.y), -walkSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(player.position.x, transform.position.y), walkSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance &&
                     Vector2.Distance(transform.position, player.position) > nearDistance)
            {
                transform.position = this.transform.position;
            }

            if (player.position.x < transform.position.x && m_FacingRight && _pdead == false)
            {
                Flip();
            }
            else if (player.position.x > transform.position.x && !m_FacingRight && _pdead == false)
            {
                Flip();
            }

            if (_pdead == true && !m_FacingRight)
            {
                Flip();
            }
        }

        void Flip()
        {
            m_FacingRight = !m_FacingRight;

            transform.Rotate(0, 180, 0);
        }
    }


    public void TakeDamage(float damage) //Damage function
    {
        health -= damage;

        if (health <= 0)
        {
            if (_edead == false)
            {
                _money = PlayerPrefs.GetInt("money");
                _money += 150;
                PlayerPrefs.SetInt("money", _money);
            }

            Die();
        }
    }

    void Die() //Die function
    {
        _edead = true;
        Ragdoll();
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 1);
    }

    void Ragdoll()
    {
        foreach (BoxCollider2D rd in boxcols)
        {
            rd.GetComponent<Rigidbody2D>().isKinematic = false;
            rd.GetComponent<HingeJoint2D>().enabled = false;
        }
    }
}