using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MoveContrl : MonoBehaviour
{
    //Audio
    private SoundManagement audioManager;

    [Header("Stats")] public float jumpHeight; //We can set the jump height in Unity
    public float moveSpeed = 20f;
    private Rigidbody2D rig;
    public static float health = 100;
    public float realhealth;
    public static bool m_FacingRight = true;
    public static bool Pdead = false;
    [HideInInspector] public Vector2 FireRecoil;
    public Animator anim;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>(); //Our character body now equals to "rig"
    }

    private void Start()
    {
        health = Shop._curntHealth;
        Pdead = false;
        anim = GetComponent<Animator>();
        //Audio
        audioManager = SoundManagement.instance;
        if (Shop.pistol == 0)
        {
            GameObject.Find("PlayerPistol").SetActive(false);
            GameObject.Find("PlayerShotGun").SetActive(true);
        }
        else
        {
            GameObject.Find("PlayerPistol").SetActive(true);
            GameObject.Find("PlayerShotGun").SetActive(false);
        }
    }


    private void Update()
    {
        realhealth = health;
        if (Input.GetKeyDown(KeyCode.Space) && rig.position.y < 0f && MenuPause.GamePaused == false)
        {
            // When you press "space", character will jump
            rig.velocity += new Vector2(0, jumpHeight);
            audioManager.PlaySound("Jump"); //PlaySound
        }

        transform.localScale = new Vector3(1, 1, 1); //Standard sizes of our character


        if (Input.GetKey(KeyCode.DownArrow) && MenuPause.GamePaused == false
        ) // When you press Down Arrow our character going down or gets smaller 
        {
            if (transform.position.y > 4)
                rig.velocity = new Vector2(0, -jumpHeight);
            else
                transform.localScale = new Vector3(1, 0.5f, 1);
        }

        //Horizontal movement

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") - (FireRecoil.x * MoveHand.m_Right),
            0f + (FireRecoil.y * MoveHand.m_Down), 0f);

        transform.position += movement * (Time.deltaTime * moveSpeed);

        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }


        //Flip body
        if (Input.GetAxis("Horizontal") > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (Input.GetAxis("Horizontal") < 0 && m_FacingRight)
        {
            Flip();
        }

        if (Pdead == true && !m_FacingRight)
        {
            Flip();
        }

        void Flip()
        {
            m_FacingRight = !m_FacingRight;

            transform.Rotate(0f, 180, 0f);
        }
    }

    public void FireCap()
    {
        FireRecoil = Vector3.zero;
    }

    public void TakeDamage(float damage) //Damage function
    {
        health -= damage;

        if (health <= 0)
        {
            Pdead = true;
            Die();
        }
    }

    void Die() //Die function
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        audioManager.PlaySound("Die");
        fml.gameOverText.SetActive(true);
        Destroy(gameObject, 0.1f);
        StartCoroutine(DeathTime());
    }

    private IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }
}