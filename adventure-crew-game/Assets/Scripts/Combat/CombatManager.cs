using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    public void BattlefiledInitialization() 
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
        foreach (CombatEntity entity in adventurers) entity.DecideCombatAction();
        foreach (CombatEntity entity in enemies) entity.DecideCombatAction();
    }

    public CombatEntity GetOpponent(Vector3 selfPos, string tagName)
    {
        if (tagName == "Adventurer")
        {
            return GetClosestOpponent(selfPos, enemies);
        }
        else if (tagName == "Enemy")
        {
            return GetClosestOpponent(selfPos, adventurers);
        }
        else
        {
            Debug.LogError("Wrong tag name!");
            return null;
        }
    }
    private CombatEntity GetClosestOpponent(Vector3 selfPos, List<CombatEntity> opponents)
    {
        if (opponents.Count == 0) return null; //check there still are opponents in the scene

        CombatEntity target = null;
        float distance = float.MaxValue;
        foreach (CombatEntity opponent in opponents)
        {
            if ((opponent.transform.position - selfPos).magnitude < distance)
            {
                target = opponent;
                distance = (opponent.transform.position - selfPos).magnitude;
            }
        }
        return target;
    }

    public void DestroyAnEntity(CombatEntity entity, string tagName)
    {
        if (tagName == "Adventurer")
        {
            adventurers.Remove(entity);
        }
        else if (tagName == "Enemy")
        {
            enemies.Remove(entity);
        }
    }
    public void CombatOver()
    {

        // Note by Ed: this needs to be completely reworked. There should be a canvas UI element that pops up, shows
        // the player the results and then gives them a button to return to the map scene at their leisure.
        // for now though, it will have to do.
        Debug.Log("Combat over!!!");
        if (adventurers.Count == 0)
        {
            if (combatEnded != null) combatEnded(false);
            print("You lose!!!");
        }
        else if (enemies.Count == 0)
        {
            if (combatEnded != null) combatEnded(true);
            print("You won!!!");
            CombatData.lastCombatWon = true;
        }
        else Debug.LogWarning("If you get this message, there is a bug, Tsingtao");

        //Back to the map scene we go.
        //SceneManager.LoadScene(1);
        
    }
    public Action<bool> combatEnded;
    //this action is subscribed by: CombatStageController
}
