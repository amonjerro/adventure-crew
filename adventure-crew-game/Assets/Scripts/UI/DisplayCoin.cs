using Backend;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayCoin : MonoBehaviour
{
    public TMP_Text coinText;

    private void Start()
    {
        coinText = GetComponent<TMP_Text>();
        InvokeRepeating(nameof(updateCoinText), 0.0f, 1.0f);
    }

    private void updateCoinText()
    {
        coinText.text = "Gold: " + CurrencySystem.Coins.ToString();
    }
}