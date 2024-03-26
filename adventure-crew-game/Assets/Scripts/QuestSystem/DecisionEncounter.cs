using UnityEngine;

[CreateAssetMenu(menuName = "SOs/DecisionEncounter")]
public class DecisionEncounter : Encounter
{
    [TextArea]
    public string encounterText;
    public string decision1Text;
    public string decision2Text;
    public GameObject decisionUI;
    
    public override void OnStart()
    {

    }

    public override void OnEnd()
    {

    }

    public void Decision1()
    {
        // Do something
        
        OnEnd();
    }

    public void Decision2()
    {
        // Do something

        OnEnd();
    }
}