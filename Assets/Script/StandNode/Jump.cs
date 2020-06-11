using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Jump : MonoBehaviour
{
    //Audio
    private SoundManagement audioManager;

    //PlayerStats
    public float jumpHeight;
    public float JumpMax;
    public float PlayerHeightY;
    public float PlayerHeightX;
    public float PlayerSquatSize;
    public float PlayerSpeed;
    public float PlayerMinSquat;


    private Rigidbody2D rig;
    private PlayerStat _playerPar;
    public float _aceleration;
    private static bool _death;
    
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>(); //Our character body now equals to "rig"
    }

    void Start()
    {
        //Audio
        audioManager = SoundManagement.instance;

        //Imports Player stats from Container
        if (SceneManager.GetActiveScene().name == "Caveman")
        {
            _playerPar = PlayerStatContainer.Caveman;
            _aceleration = PlayerStatContainer.Caveman.PlayerSpeed;
        }
        else if (SceneManager.GetActiveScene().name == "Mystical Forest")
        {
            _playerPar = PlayerStatContainer.MysticalForest;
            _aceleration = PlayerStatContainer.MysticalForest.PlayerSpeed;
        } else if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            _playerPar = PlayerStatContainer.SampleScene;
            _aceleration = PlayerStatContainer.SampleScene.PlayerSpeed;
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(_aceleration * Time.deltaTime, 0, 0);

        if (_aceleration <= 9f)
        {
            _aceleration += _aceleration / 7500;
        }

        jumpHeight = _playerPar.jumpHeight;
        JumpMax = _playerPar.JumpMax;
        PlayerHeightY = _playerPar.PlayerHeightY;
        PlayerHeightX = _playerPar.PlayerHeightX;
        PlayerSquatSize = _playerPar.PlayerSquatSize;
        PlayerSpeed = _playerPar.PlayerSpeed;
        PlayerMinSquat = _playerPar.PlayerMinSquat;
    }


    void Update()
    {
        _death = GroundObstacleDeath.IsDeath;
        
        if (Input.GetKeyDown(KeyCode.Space) && (rig.position.y < _playerPar.JumpMax) && (_death==false)
        ) //Jump function, on press Space and Height<4
        {
            // When you press "space", character will jump
            rig.velocity += new Vector2(0, _playerPar.jumpHeight);
            audioManager.PlaySound("Jump"); //PlaySound
        }

        transform.localScale = new Vector3(_playerPar.PlayerHeightX, _playerPar.PlayerHeightY, 1); //Standard sizes of our character


        if (Input.GetKey(KeyCode.DownArrow) && (_death==false)) // When you press Down Arrow our character going down or gets smaller 
        {
            if (transform.position.y > _playerPar.PlayerMinSquat) //If height>4, character going down faster
            {
                rig.velocity = new Vector2(0, -_playerPar.jumpHeight);
            }
            else //Else it becomes smaller
            {
                transform.localScale = new Vector3(_playerPar.PlayerHeightX, _playerPar.PlayerSquatSize, 1); //Transforms character height 1/2
            }
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}