using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AdventurerUIElement : MonoBehaviour
{
    public int ID;
    public TMP_Text rankText;
    public TMP_Text exhaustionText;

    public void Init(int ID, Adventurer.Rank rank, int exhaustion)
    {
        this.ID = ID;
        rankText.text = rank.ToString();
        exhaustionText.text = exhaustion.ToString();
    }
}
