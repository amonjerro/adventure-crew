using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombatStageController : MonoBehaviour
{
    public Button startCombatButton;
    public Button backToMapButton;
    public Button fleeButton;
    public GameObject formationUI;
    public GameObject postCombatUI;
    public GameObject powerUI;

    public TMP_Text resultText;
    private void OnEnable()
    {
        startCombatButton.onClick.AddListener(StartCombat);
        backToMapButton.onClick.AddListener(GoBackToMap);
        fleeButton.onClick.AddListener(GoBackToMap);
        CombatManager.Instance.combatEnded += EndCombat;

        startCombatButton.interactable = false;
        FollowMouse.ReadyToFight += () => startCombatButton.interactable = true;
    }
    private void OnDisable()
    {
        startCombatButton.onClick.RemoveAllListeners();
        backToMapButton.onClick.RemoveAllListeners();
        fleeButton.onClick.RemoveAllListeners();
        CombatManager.Instance.combatEnded -= EndCombat;

        FollowMouse.ReadyToFight -= () => startCombatButton.interactable = true;
    }
    private void Start()
    {
        formationUI.SetActive(true);
        postCombatUI.SetActive(false);
        powerUI.SetActive(false);
    }
    private void StartCombat()
    {
        CombatManager.Instance.BattlefiledInitialization();
        formationUI.SetActive(false);
        powerUI.SetActive(true);
    }
    private void EndCombat(bool win)
    {
        postCombatUI.SetActive(true);
        powerUI.SetActive(false);
        if (win) resultText.text = "You won!";
        else resultText.text = "You lost!";
    }
    private void GoBackToMap()
    {
        AdventurerList.ExhaustAdventurers();
        SceneManager.LoadScene(1);
    }
}
