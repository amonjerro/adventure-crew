using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombatStageController : MonoBehaviour
{
    public Button startCombatButton;
    public GameObject formationUI;
    public GameObject postCombatUI;
    public Button backToMapButton;
    public TMP_Text resultText;
    private void OnEnable()
    {
        startCombatButton.onClick.AddListener(StartCombat);
        backToMapButton.onClick.AddListener(GoBackToMap);
        CombatManager.Instance.combatEnded += EndCombat;
    }
    private void OnDisable()
    {
        startCombatButton.onClick.RemoveAllListeners();
        backToMapButton.onClick.RemoveAllListeners();
        CombatManager.Instance.combatEnded -= EndCombat;
    }
    private void Start()
    {
        formationUI.SetActive(true);
        postCombatUI.SetActive(false);
    }
    private void StartCombat()
    {
        CombatManager.Instance.BattlefiledInitialization();
        formationUI.SetActive(false);
    }
    private void EndCombat(bool win)
    {
        postCombatUI.SetActive(true);
        if (win) resultText.text = "You won!";
        else resultText.text = "You lost!";
    }
    private void GoBackToMap()
    {
        SceneManager.LoadScene(1);
    }
}
