using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class Buildings : MonoBehaviour
{

    public bool isCompleted;
    public bool isInTrigger;
    public int neededWoodStartValue;
    [HideInInspector] public int neededWood;
    public int rewardCoin;
    public int increaseAmount;

    public TextMesh neededWoodText;

    public GameObject buildingArea;
    public GameObject completedStructure;

    public List<GameObject> parts;
    int artansayi;

    private void Start()
    {


        increaseAmount = (neededWoodStartValue / 2) / parts.Count;
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

        if(neededWoodStartValue != neededWood)
        {
            foreach (GameObject part in parts)
            {
                part.gameObject.SetActive(false);
            }
        }

        if (artansayi > increaseAmount)
        {
            if (parts.Count != 0)
            {
                parts[0].gameObject.SetActive(true);
                parts.Remove(parts[0]);
                artansayi = 0;
            }
        }

        neededWoodText.text = neededWood.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInTrigger = true;
            StartCoroutine(BuildingStructure());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
    }

    IEnumerator BuildingStructure()
    {
        while (true)
        {
            if (PlayerController.Instance.wood.amount > 0 && neededWood > 0)
            {
                neededWood--;
                artansayi++;
                PlayerController.Instance.wood.amount--;
                yield return new WaitForSeconds(.05f);
            }

            if (PlayerController.Instance.wood.amount <= 0 || neededWood <= 0 || !isInTrigger)
            {
                break;
            }
        }
    }
}
