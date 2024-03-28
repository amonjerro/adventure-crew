using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    List<Battle> activeBattles;
    private bool _isRendering;
    private Battle _renderedBattle;

    [SerializeField]
    private BattleUI screen;

    private void Start()
    {
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

}
