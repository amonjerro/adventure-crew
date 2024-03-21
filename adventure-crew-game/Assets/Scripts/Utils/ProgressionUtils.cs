using UnityEngine;
public static class ProgressionUtils
{
    public static int CalculateLevel(int xp)
    {
        // Progression follows the following rule: 100 to level 2, 300 to level 3, 600 to level 4, so on
        // See this for reference https://www.desmos.com/calculator/1xnmnw4nsx
        return (int)(1 + Mathf.Sqrt(1 + 0.08f * xp))/2; 
    }
}
