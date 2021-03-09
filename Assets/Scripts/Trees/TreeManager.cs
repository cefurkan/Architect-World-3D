using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    [SerializeField]
    private float treeWoodCount = 5;
    public bool isTreeFinished;

// 13. satırdaki kodun aynısını yapıyor.    
    public float TreeWoodCount { get { return treeWoodCount; } }

    //public int TreeWoodCount()
    //{
    //    return treeWoodCount;
    //}

    public void DecreaseWoodCount(float decreaseAmount)
    {
        treeWoodCount = treeWoodCount - decreaseAmount;
        PlayerController.Instance.wood.amount++;

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
