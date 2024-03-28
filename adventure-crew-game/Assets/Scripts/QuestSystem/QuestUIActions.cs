
public enum ActionTypes
{
    Reject,
    Accept,
    Disengage,
    NextEncounter
}

public enum SelectionActions
{
    MovePlayer,
    RenderBattle
}

public static class ActionFactory
{
    public static IQuestUIAction MakeUIAction(ActionTypes type)
    {
        switch (type)
        {

            case ActionTypes.Accept:
                return new Accept();
            case ActionTypes.Disengage:
                return new Disengage();
            case ActionTypes.NextEncounter:
                return new NextEncounter();
            default:
                return new Reject();
        }
    }

    public static ILocationSelectAction MakeLocationAction(SelectionActions type)
    {
        switch (type)
        {
            case SelectionActions.RenderBattle:
                return new RenderLocation();
            default:
                return new MovePlayer();
        }
    }
} 

public interface ILocationSelectAction
{
    public void Perform(QuestSelection qs);
}

public class RenderLocation : ILocationSelectAction
{
    public void Perform(QuestSelection qs)
    {
        // do eet
    }
}

public class MovePlayer : ILocationSelectAction
{
    public void Perform(QuestSelection qs)
    {
        qs.MovePlayer();
    }
}

public interface IQuestUIAction
{
    public void Perform(QuestUIManager uiM);
}

public class Accept : IQuestUIAction
{
    public void Perform(QuestUIManager uiM)
    {
        uiM.AcceptQuest();
    }
}

public class Reject : IQuestUIAction
{
    public void Perform(QuestUIManager uiM)
    {
        uiM.RejectQuest();
    }
}

public class Disengage : IQuestUIAction
{
    public void Perform(QuestUIManager uiM)
    {
        uiM.GetComponentInParent<QuestManager>().Disengage();
        uiM.gameObject.SetActive(false);
    }
}

public class NextEncounter : IQuestUIAction
{
    public void Perform(QuestUIManager uiM)
    {
        QuestManager qm = uiM.GetComponentInParent<QuestManager>();
        qm.LoadNextEncounter();
    }
}