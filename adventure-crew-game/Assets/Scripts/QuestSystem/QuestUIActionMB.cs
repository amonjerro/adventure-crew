using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class QuestUIAction : MonoBehaviour
{
	public ActionTypes action;
    private IQuestUIAction buttonEffect;

    private void Awake()
    {
        buttonEffect = ActionFactory.MakeUIAction(action);
    }

    public void SetAction(ActionTypes type)
    {
        action = type;
        buttonEffect = ActionFactory.MakeUIAction(action);
    }

    public void DoYourThing()
    {
        buttonEffect.Perform(GetComponentInParent<QuestUIManager>());
    }
}