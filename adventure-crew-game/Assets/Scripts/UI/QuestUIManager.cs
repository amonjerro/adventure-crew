using TMPro;
using UnityEngine;

public class QuestUIManager : UIMenu
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI secondButtonText;
    public GameObject firstButton;
    public GameObject panel;
    public GameObject nextEncounterButton;
    Quest content;

    public void UpdateUI(Quest q)
    {
        nextEncounterButton.SetActive(false);
        panel.SetActive(true);
        title.text = q.questTitle;
        description.text = q.description;
        firstButton.GetComponentInChildren<TextMeshProUGUI>().text = "Accept Quest";
        firstButton.GetComponent<QuestUIAction>().SetAction(ActionTypes.Accept);
        secondButtonText.text = "Reject";
        content = q;
    }

    public void ShowNoQuests()
    {
        nextEncounterButton.SetActive(false);
        panel.SetActive(true);
        firstButton.SetActive(false);
        title.text = "";
        description.text = "Nothing remains to be done here";
        secondButtonText.text = "Dismiss";
    }

    public void AcceptQuest()
    {
        QuestManager qm = GetComponentInParent<QuestManager>();
        qm.EngageQuest(content);
        ShowEncounterButton();
        
    }

    public void RejectQuest()
    {
        // Dismiss this window
        panel.SetActive(false);
        QuestManager qm = GetComponentInParent<QuestManager>();
        if (!qm.IsEngaged())
        {
            gameObject.SetActive(false);
        } else
        {
            nextEncounterButton.SetActive(true);
        }
    }

    public void ShowDisengage()
    {
        panel.SetActive(true);
        title.text = "";
        description.text = "Are you sure you want to move? You'll leave this quest unfinished and will have to start again.";
        firstButton.GetComponentInChildren<TextMeshProUGUI>().text = "Disengage";
        firstButton.GetComponent<QuestUIAction>().SetAction(ActionTypes.Disengage);
        secondButtonText.text = "Reconsider";
        nextEncounterButton.SetActive(false);
    }

    public void ShowEncounterButton()
    {
        panel.SetActive(false);
        nextEncounterButton.SetActive(true);
    }
}