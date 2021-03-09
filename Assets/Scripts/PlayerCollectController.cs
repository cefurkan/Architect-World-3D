using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    [SerializeField]
    private int collectedWoodCount;
    private bool isCurrentTreeFinished;
    private TreeManager currentTree;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            if (currentTree!= null)
            {
                return;
            }
            currentTree = other.gameObject.GetComponentInParent<TreeManager>();
            OnNearTree();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponentInParent<TreeManager>() ==currentTree )
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
        while (!isCurrentTreeFinished && currentTree!=null)
        {
            collectedWoodCount++;
            currentTree.DecreaseWoodCount();

            if (currentTree.isTreeFinished)
            {
                isCurrentTreeFinished = true;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

}
