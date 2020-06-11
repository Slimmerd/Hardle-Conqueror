using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject,1);
    }
}
