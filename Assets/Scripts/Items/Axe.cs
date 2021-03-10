﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public static Axe Instance => instance;
    private static Axe instance;

    private float speed = 2f;
    private float power = .5f;

    public TreeManager currentTree;

    private void Awake()
    {
        // İleride Axe'ı Scriptable Objectden farklı itemlarla çekebiliriz,
        // O yüzden singleton yazdım. Şu an işimize yaramıyor fakat yarayacaktır.
        
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            Debug.Log("girdim");
            currentTree = other.gameObject.GetComponentInParent<TreeManager>();

            if (currentTree != null)
            {
                OnNearTree();

            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        AwayFromTree();
        if (other.gameObject.GetComponentInParent<TreeManager>() == currentTree)
        {
           
        }
    }

    private void OnNearTree()
    {
        StartCoroutine(CR_OnNeartree());
    }

    private void AwayFromTree()
    {
        currentTree = null;
        StopCoroutine(CR_OnNeartree());
        Debug.Log("çıktım");

    }
    private IEnumerator CR_OnNeartree()
    {
        while (currentTree != null)
        {
            currentTree.DecreaseWoodCount(power);

            if (currentTree.isTreeFinished)
            {
                break;
            }
            Debug.Log("vurdum" + currentTree.TreeWoodCount);

           PlayerController.Instance.anim.SetTrigger("Melee");
            yield return new WaitForSeconds(speed);

        }

    }
}
