using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerDisplay : MonoBehaviour
{
    public Button generateButton;
    public Button deleteButton;
    [Header("Assets/Prefabs/UI/AdventurerInfo")]
    public GameObject UIPrefab;

    [Header("UI element's parent")]
    public GameObject content;

    //Don't show it, otherwise it causes a unity buf with inspector
    private void Start()
    {
        if(generateButton != null) generateButton.onClick.AddListener(Generate);
        if(deleteButton != null) deleteButton.onClick.AddListener(Remove);

        UpdateDisplay();
    }
    private void OnDisable()
    {
        if(generateButton != null) generateButton.onClick.RemoveAllListeners();
        if (deleteButton != null) deleteButton.onClick.RemoveAllListeners();
    }

    public void Generate()
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
        for (int i = 0; i < AdventurerList.Adventurers.Count; i++)
        {
            AdventurerUIElement element = Instantiate(UIPrefab, content.transform).GetComponent<AdventurerUIElement>();
            element.Init(i, AdventurerList.Adventurers[i].rank, AdventurerList.Adventurers[i].Exhaustion);
        }
    }
    
}
