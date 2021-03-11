using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsManager : MonoBehaviour
{

    public List<Buildings> buildings;



    public void Part1Button()
    {
        if(buildings[0].neededWood1 <= PlayerController.Instance.wood.amount)
        {
            buildings[0].part1.SetActive(true);
            PlayerController.Instance.wood.amount -= buildings[0].neededWood1;
            Debug.Log("Part1 Tamam");
        }
        else
        {
            Debug.Log("Not Enough Wood!");
        }

    }

    public void Part2Button()
    {
        if (buildings[0].neededWood2 <= PlayerController.Instance.wood.amount)
        {
            buildings[0].part2.SetActive(true);
            PlayerController.Instance.wood.amount -= buildings[0].neededWood2;
            Debug.Log("Part2 Tamam");
        }
        else
        {
            Debug.Log("Not Enough Wood!");
        }

    }

    public void Part3Button()
    {
        if (buildings[0].neededWood3 <= PlayerController.Instance.wood.amount)
        {
            buildings[0].part3.SetActive(true);
            PlayerController.Instance.wood.amount -= buildings[0].neededWood3;
            StartCoroutine(Part4());
            Debug.Log("Part2 Tamam");
        }
        else
        {
            Debug.Log("Not Enough Wood!");
        }

    }

    IEnumerator Part4()
    {
        yield return new WaitForSeconds(1.5f);
        buildings[0].part1.SetActive(false);
        buildings[0].part2.SetActive(false);
        buildings[0].part3.SetActive(false);
        buildings[0].part4.SetActive(true);
        buildings.Remove(buildings[0]);
        //TO DO: Gerçek dünyada ana binayı SetActive(true) && Para kazanma

    }


}
