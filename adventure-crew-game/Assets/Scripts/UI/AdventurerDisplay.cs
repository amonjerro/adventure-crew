using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerDisplay : MonoBehaviour
{
    public Button generateButton;
    public Button deleteButton;
    public GameObject UIPrefab;

    [Header("UI element's parent")]
    public GameObject content;
    private void Start()
    {
        generateButton.onClick.AddListener(Generate);
        deleteButton.onClick.AddListener(Remove);
    }

    private void Generate()
    {
        AdventurerList.AddAnAdventurer();

        UpdateDisplay();
    }
    private void Remove()
    {
        if (AdventurerList.Adventurers.Count <= 0) return;
        System.Random rnd = new System.Random();
        int index = rnd.Next(0, AdventurerList.Adventurers.Count);
        AdventurerList.RemoveAnAdventurer(index);
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        AdventurerUIElement[] allChildren = content.GetComponentsInChildren<AdventurerUIElement>();
        foreach (AdventurerUIElement child in allChildren)
        {
            Destroy(child.gameObject);
        }
        string log = "";
        for (int i = 0; i < AdventurerList.Adventurers.Count; i++)
        {
            log += AdventurerList.Adventurers[i].XP.ToString() + " ";
            AdventurerUIElement element = Instantiate(UIPrefab, content.transform).GetComponent<AdventurerUIElement>();
            element.UpdateInfo(AdventurerList.Adventurers[i].XP, AdventurerList.Adventurers[i].Exhaustion);
        }
        //print(log);
    }
    
}
