using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerListInitializer : MonoBehaviour
{
    public int initialAdventurerAmount = 5;
    void Start()
    {
        if (AdventurerList.Adventurers.Count > 0) return;

        for (int i = 0; i < initialAdventurerAmount; i++)
        {
            AdventurerList.AddAnAdventurerNoSort();
        }
        AdventurerList.QuickSort(ref AdventurerList.Adventurers, 0, AdventurerList.Adventurers.Count - 1);

        for(int i = 0; i < AdventurerList.Adventurers.Count; i++)
        {
            print(AdventurerList.Adventurers[i].rank.ToString());
        }
    }


}
