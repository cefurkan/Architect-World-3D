using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class Buildings : MonoBehaviour
{

    public bool isCompleted;
    public bool osman;
    public int neededWoodStartValue;
    [HideInInspector] public int neededWood;
    public int rewardCoin;

    public TextMesh neededWoodText;

    public int mahmut = 0;

    public GameObject buildingArea;
    public GameObject completedStructure;

    public List<GameObject> parts;
    int artansayi;


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

        foreach (GameObject part in parts)
        {
            part.gameObject.SetActive(false);
        }
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

        // YALNIZ BU İŞ BÖYLE OLMAZ SEN BUNU ELSE İFLE YAP imza: thrcgr;
        //for (int f = 2, i = 0; f <= parts.Count * 2; f += 2, i += 1)
        //{
        //    if (neededWoodStartValue * f / 10 == neededWood)
        //    {
        //        neededWood -= neededWoodStartValue * f / 10;
        //        parts[i].gameObject.SetActive(true);
        //        parts.Remove(parts[i]);

        //    }
        //}

        // parts sayısını ikiye bölüyorum, 




        //for (int i = 0; i < parts.Count; i++)
        //{

        //    if (busayidabirarttir < artansayi)
        //    {
        //        parts[i].gameObject.SetActive(true);

        //    }
        //    else if (artansayi  >= busayidabirarttir)
        //    {
        //        artansayi = 0;

        //    }

        var increaseAmount = (neededWoodStartValue / 2) / parts.Count;

        if (artansayi > increaseAmount)
        {
            parts[0].gameObject.SetActive(true);
            parts.Remove(parts[0]);
            artansayi = 0;
        }

        neededWoodText.text = neededWood.ToString();
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
                artansayi++;
                PlayerController.Instance.wood.amount--;
                yield return new WaitForSeconds(.05f);
            }

            if (PlayerController.Instance.wood.amount <= 0 || neededWood <= 0 || !osman)
            {
                break;
            }
        }
    }
}
