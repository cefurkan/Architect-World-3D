using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text woodText;
   
    private void UpdateWoodCounter()
    {
        woodText.text = PlayerController.Instance.wood.amount.ToString();
    }
    private void Update()
    {
        UpdateWoodCounter();
    }
}
