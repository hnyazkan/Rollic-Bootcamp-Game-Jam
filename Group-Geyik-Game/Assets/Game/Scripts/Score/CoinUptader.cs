using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinUIController : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
 
    void Start()
    {

        coinsText = gameObject.GetComponent<TextMeshProUGUI>();
    }

 
    void Update()
    {
        ChangeCoinText();
    }

    public void ChangeCoinText()
    {
        coinsText.text = Score.totalCoin.ToString();
    }
}
