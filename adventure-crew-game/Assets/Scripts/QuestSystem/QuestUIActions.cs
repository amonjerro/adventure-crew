
public enum ActionTypes
{
    Reject,
    Accept,
    Disengage,
    NextEncounter
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