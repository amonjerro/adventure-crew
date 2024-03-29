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

    public void Init(int ID)
    {
        this.ID = ID;
        rankText.text = AdventurerList.Adventurers[ID].rank.ToString();
        exhaustionText.text = AdventurerList.Adventurers[ID].Exhaustion.ToString();
    }
}
