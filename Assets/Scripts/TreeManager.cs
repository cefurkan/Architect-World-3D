using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    private int treeWoodCount = 5;
    public bool isTreeFinished;


    public int GetTreeWoodCount()
    {
        return treeWoodCount;
    }

    public void DecreaseWoodCount()
    {
        treeWoodCount--;
        if (treeWoodCount == 0)
        {
            isTreeFinished = true;
            DestroyFinishedTree();
        }

    }
    public void DestroyFinishedTree()
    {
        gameObject.SetActive(false);
    }

}
