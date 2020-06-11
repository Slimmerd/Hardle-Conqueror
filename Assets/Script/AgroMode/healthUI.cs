using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthUI : MonoBehaviour
{
    private void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text =
            "Health:" + MoveContrl.health;
    }
}
