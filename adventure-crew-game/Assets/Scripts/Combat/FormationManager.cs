using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormationManager : MonoBehaviour
{
    public GameObject Adventurer;
    public CombatStatsSO statsSO;
    #region Singleton
    public static FormationManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    #endregion

    public void SpawnAdventurer()
    {
        GameObject go = Instantiate(Adventurer);
        go.GetComponent<CombatEntityAdventurer>().combatStatsSO = statsSO;
        go.AddComponent<FollowMouse>();

    }

}
