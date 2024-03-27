using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdventurerUIElement : MonoBehaviour
{
    public TMP_Text XP;
    public TMP_Text exhaustionText;

    public void UpdateInfo(int level, int exhaustion)
    {
        XP.text = level.ToString();
        exhaustionText.text = exhaustion.ToString();
    }
}
