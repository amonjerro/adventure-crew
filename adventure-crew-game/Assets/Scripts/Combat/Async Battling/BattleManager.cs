using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    List<Battle> activeBattles;
    private bool _isRendering;
    private Battle _renderedBattle;

    [SerializeField]
    private BattleUI screen;

    private void Update()
    {
        foreach(Battle b in activeBattles)
        {
            b.ProcessTick();
        }

        if (_isRendering)
        {
            screen.RenderBattleStatus(_renderedBattle);
        }
    }

    public void InspectBattle(int i)
    {
        _renderedBattle = activeBattles[i];
        _isRendering = true;
    }

    public void CloseRenderScreen()
    {
        _renderedBattle = null;
        _isRendering = false;
    }

}
