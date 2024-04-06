using UnityEngine;

namespace Backend
{
    public class CurrencySystem
    {
        public static CurrencySystem Instance => s_instance ?? new CurrencySystem();
        private static CurrencySystem s_instance;

        public static int Coins { get; private set; }
        private const int StartingCoins = 100;

        public static CurrencySystem Activate()
        {
            return Instance;
        }
        
        private CurrencySystem()
        {
            Coins = PlayerPrefs.GetInt("Coins", StartingCoins);
        }

        public static void AddCoins(int amount)
        {
            Coins += amount;
            PlayerPrefs.SetInt("Coins", Coins);
        }

        public static bool RemoveCoins(int amount)
        {
            if (Coins < amount) return false;

            Coins -= amount;
            PlayerPrefs.SetInt("Coins", Coins);
            return true;
        }
    }
}