using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class AdventurerUIElement : MonoBehaviour, IPointerEnterHandler, IPointerMoveHandler, IPointerExitHandler
{
    public int ID;
    public TMP_Text rankText;
    public TMP_Text exhaustionText;
    public GameObject dataElement;

    public void Init(int ID, Stats stats)
    {
        this.ID = ID;
        rankText.text = AdventurerList.Adventurers[ID].rank.ToString();
        exhaustionText.text = AdventurerList.Adventurers[ID].Exhaustion.ToString();

        //description element
        dataElement = Instantiate(Resources.Load<GameObject>("UI/dataElement"), transform.parent.parent.parent);
        dataElement.GetComponentInChildren<TMP_Text>().text = 
            "HP: " + stats.HP.ToString() + "/" + stats.MaxHP.ToString() + "\n" + 
            "Damage: " + stats.Damage.ToString() + "\n" +
            "Agility: " + stats.Agility.ToString() + "\n" +
            "Range: " + stats.Range.ToString() + "\n";
        dataElement.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        dataElement.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        dataElement.SetActive(false);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        //print("cursor location: " + eventData.position);
        dataElement.GetComponent<RectTransform>().position = eventData.position + new Vector2(100, 100);
    }

    public void UpdateExhaustion()
    {
        exhaustionText.text = AdventurerList.Adventurers[ID].Exhaustion.ToString();
    }
}
