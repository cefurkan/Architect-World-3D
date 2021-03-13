using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodFactory : MonoBehaviour
{
    public int woodAmount;
    public int maxAmount;
    public float generateTime;

    void Start()
    {
        StartCoroutine(GenerateWood());
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController.Instance.wood.amount  += woodAmount;
        woodAmount = 0;
        StartCoroutine(GenerateWood());

    }

    IEnumerator GenerateWood()
    {
        while(woodAmount < maxAmount)
        {
            woodAmount++;
            yield return new WaitForSeconds(generateTime);
        }
    }     
    
}
