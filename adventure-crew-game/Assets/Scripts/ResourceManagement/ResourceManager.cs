using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Gold gold;

    private void Awake()
    {
        gold = new Gold();
    }

    public bool TestAvailability(int cost)
    {
        return gold.CanSpend(cost);
    }

    public void ReceiveReward(int value)
    {
        gold.Add(value);
    }
}
