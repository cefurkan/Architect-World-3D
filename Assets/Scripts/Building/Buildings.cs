﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class Buildings : MonoBehaviour
{
    public GameObject completedStructure;

    [HideInInspector]
    public bool isCompleted;
    public int rewardCoin;

    BuildingArea buildingArea;

    private void Start()
    {
        buildingArea = GetComponentInChildren<BuildingArea>();
        isCompleted = buildingArea.isCompleted;
    }
    private void Update()
    {
        if (buildingArea.neededWood == 0 && !buildingArea.isCompleted)
        {
            buildingArea.gameObject.SetActive(false);
            completedStructure.gameObject.SetActive(true);
            PlayerController.Instance.gold.amount += rewardCoin;
            buildingArea.isCompleted = true;
        }
    }
}
