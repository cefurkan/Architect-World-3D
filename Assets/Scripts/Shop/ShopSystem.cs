using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    
    public GameObject shopUI;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        shopUI.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        shopUI.gameObject.SetActive(false);
    }
    public void SpeedUp()
    {
       Axe.Instance.meleeSpeed += 1;
        PlayerController.Instance.anim.SetFloat("MeleeSpeed", 1f + Axe.Instance.meleeSpeed);
    }
    public void PowerUp()
    {
        Axe.Instance.power += 1;
    }
}
