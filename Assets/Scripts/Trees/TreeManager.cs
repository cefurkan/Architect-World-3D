using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public float TreeWoodCount { get { return treeWoodCount; } }

    private int treeWoodCount;

    [SerializeField]
    private int treeStartWoodCount = 15;

    public bool isTreeFinished;

    public Transform logDropPosition;
     GameObject logPrefab;

    private void Start()
    {
        treeWoodCount = treeStartWoodCount;
        logPrefab = Resources.Load<GameObject>("WoodLog");
    }

    public void DecreaseWoodCount(int decreaseAmount)
    {
        treeWoodCount = treeWoodCount - decreaseAmount;
        PlayerController.Instance.wood.amount += Mathf.RoundToInt(decreaseAmount);
        Instantiate(logPrefab, logDropPosition.position, Quaternion.identity);

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
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }

        treeRenderer.enabled = false;
        yield return new WaitForSeconds(delay);

        foreach (Collider collider in colliders)
        {
            collider.enabled = true;

        }

        treeWoodCount = treeStartWoodCount;
        treeRenderer.enabled = true;
        isTreeFinished = false;
    }
}
