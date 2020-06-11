using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSys : MonoBehaviour
{
   private float score = 0; //Def variable score

   void FixedUpdate()
   {
      GetComponent<TextMeshProUGUI>().text =
         "Score:" + Mathf.RoundToInt(score); //In text where wrote "score" it will round and write score
      score += 0.25f; //Counting our score
   }
}
