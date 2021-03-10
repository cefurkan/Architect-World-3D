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

        if (treeWoodCount <= 0)
        {
            isTreeFinished = true;
            DisableAndRefreshAfterDelay(5f);
        }
    }

    public void DestroyFinishedTree()
    {
        gameObject.SetActive(false);
    }
    private void DisableAndRefreshAfterDelay(float delay)
    {
        StartCoroutine(CR_DisableAndRefreshAfterDelay(delay));
    }
    private IEnumerator CR_DisableAndRefreshAfterDelay(float delay)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();
        Renderer treeRenderer = GetComponent<Renderer>();
        foreach(Collider collider in colliders)
        {
            collider.enabled = false;
        }

        treeRenderer.enabled = false;
        yield return new WaitForSeconds(delay);

        foreach (Collider collider in colliders)
        {
            collider.enabled = true;

        }


        treeWoodCount = 5;
        treeRenderer.enabled = true;
        isTreeFinished = false;
    }
}
