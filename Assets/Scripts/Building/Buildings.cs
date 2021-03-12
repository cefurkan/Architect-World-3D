using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{

    public bool isCompleted;
    public bool osman;
    public int neededWoodStartValue;
    [HideInInspector] public int neededWood;
    public int rewardCoin;

    public int mahmut = 0;

    public GameObject buildingArea;
    public GameObject completedStructure;

    public GameObject[] parts;


    //public int neededWood1;
    //public int neededWood2;
    //public int neededWood3;

    //public GameObject part1;
    //public GameObject part2;
    //public GameObject part3;
    //public GameObject part4;

    private void Start()
    {
        neededWood = neededWoodStartValue;
    }
    private void Update()
    {
        if (neededWood == 0 && !isCompleted)
        {
            buildingArea.gameObject.SetActive(false);
            completedStructure.gameObject.SetActive(true);
            PlayerController.Instance.gold.amount += rewardCoin;
            isCompleted = true;
        }

     
       
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            osman = true;
            StartCoroutine(BuildingStructure());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        osman = false;
    }

    IEnumerator BuildingStructure()
    {
        while (true)
        {
            if (PlayerController.Instance.wood.amount > 0 && neededWood > 0)
            {
                neededWood--;
                PlayerController.Instance.wood.amount--;
                yield return new WaitForSeconds(.05f);
            }

            if(PlayerController.Instance.wood.amount <= 0 || neededWood <= 0 || !osman) 
            {
                break;
            }

        }


    }



}
