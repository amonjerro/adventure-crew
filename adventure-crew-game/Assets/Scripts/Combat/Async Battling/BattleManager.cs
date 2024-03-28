using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }



    List<Battle> activeBattles;
    private bool _isRendering;
    private Battle _renderedBattle;

    [SerializeField]
    private BattleUI screen;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        } else
        {
            Instance = this;
        }

        activeBattles = new List<Battle>();
    }

    private void Update()
    {
        foreach(Battle b in activeBattles)
        {
            b.ProcessTick();
        }

        if (_isRendering)
        {
            screen.RenderBattleStatus();
        }
    }

    public void InspectBattle(int i)
    {
        _renderedBattle = activeBattles[i];
        screen.b = _renderedBattle;
        screen.gameObject.SetActive(true);
        _isRendering = true;
    }

    public Battle GetBattleByIndex(int index)
    {
        return activeBattles[index];
    }

}
