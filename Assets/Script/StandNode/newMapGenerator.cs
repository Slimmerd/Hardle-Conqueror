using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class newMapGenerator : MonoBehaviour
{
    private const float SPAWN_DISTANCE = 50f;
    public Transform startLevel;
    public List<Transform> LevelPartList;
    public Jump player;

    private Vector3 lastEndPoint;

    private void Awake()
    {
        lastEndPoint = startLevel.Find("EndPoint").position;
        int defaultLevelSpawn = 1;
        for (int i = 0; i < defaultLevelSpawn; i++)
        {
            generateNewPart();
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(player.GetPosition(),lastEndPoint)<SPAWN_DISTANCE)
        {
            generateNewPart();
        }
    }

    private void generateNewPart()
    {
        Transform chosenLevelPart = LevelPartList[Random.Range(0,LevelPartList.Count)];
        Transform lastLevelPartTransform = generateNewPart(chosenLevelPart,lastEndPoint);
        lastEndPoint = lastLevelPartTransform.Find("EndPoint").position;
    }

    private Transform generateNewPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}

