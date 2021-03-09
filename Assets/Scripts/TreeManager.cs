using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    private int treeWoodCount = 5;
    public bool isTreeFinished;

// 13. satırdaki kodun aynısını yapıyor.    
    public int TreeWoodCount { get { return treeWoodCount; } }

    //public int TsreeWoodCount()
    //{
    //    return treeWoodCount;
    //}

    public void DecreaseWoodCount(int decreaseAmount)
    {
        treeWoodCount-= decreaseAmount;
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
