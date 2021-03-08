using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    [SerializeField]
    private int collectedWoodCount;
    private bool isTreeFinish;
    private GameObject currentTree;

    private int currentWoodCollectedFromTree;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            if (currentTree!= null)
            {
                return;
            }
            currentTree = other.gameObject;
            OnNearTree();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject ==currentTree )
        {
            AwayFromTree();
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

    }
    private IEnumerator CR_OnNeartree()
    {
        while (!isTreeFinish && currentTree!=null)
        {
            collectedWoodCount++;
            currentWoodCollectedFromTree++;
            if (currentWoodCollectedFromTree==5)
            {
                isTreeFinish = true;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

}
