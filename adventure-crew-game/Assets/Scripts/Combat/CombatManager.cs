using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<CombatEntity> adventurers = new List<CombatEntity>();
    public List<CombatEntity> enemies = new List<CombatEntity>();

    //probably waiting for the singleton service
    #region Singleton
    public static CombatManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    #endregion
    private void Start()
    {
        if (!StartCombat())
        {
            Debug.Log("Not able to start the game");
            return;
        }

        InitializeEntities();
    }

    public bool StartCombat()
    {
        GameObject[] adventurerObjs = GameObject.FindGameObjectsWithTag("Adventurer");
        GameObject[] enemyObjs = GameObject.FindGameObjectsWithTag("Enemy");
        if (adventurerObjs.Length == 0 || enemyObjs.Length == 0)
        {
            Debug.LogWarning("No adventurer or enemy placed in the scene, the combat can't start");
            return false; 
        }

        for (int i = 0; i < adventurerObjs.Length; i++) adventurers.Add(adventurerObjs[i].GetComponent<CombatEntity>());
        for (int i = 0; i < enemyObjs.Length; i++) enemies.Add(enemyObjs[i].GetComponent<CombatEntity>());
        return true;
    }
    public void InitializeEntities()
    {
        foreach (CombatEntity entity in adventurers) entity.DecideCombatState();
        foreach (CombatEntity entity in enemies) entity.DecideCombatState();
    }
    public void CombatOver()
    {
        Debug.Log("Combat over!!!");
    }
}
