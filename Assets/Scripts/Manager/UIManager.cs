using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text woodText;
    public Text goldText;


    private void UpdateResources()
    {
        woodText.text = PlayerController.Instance.wood.amount.ToString();
        goldText.text = PlayerController.Instance.gold.amount.ToString();
    }
    private void Update()
    {
        UpdateResources();
    }
}
