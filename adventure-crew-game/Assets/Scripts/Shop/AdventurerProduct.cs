using System;
using Backend;
using UnityEngine;

namespace Shop
{
    [Serializable]
    public class AdventurerProduct : Product
    {
        [SerializeField] private Adventurer.Rank adventurerRank;
        public override bool TryPurchaseProduct(out string errorMessage)
        {
            errorMessage = "";
            if (!CurrencySystem.RemoveCoins((int)Price))
            {
                errorMessage = "Not enough gold!";
                OnPurchaseFailed();
                return false;
            }
            
            OnPurchaseSuccessful();
            return true;
        }

        public override void OnPurchaseSuccessful()
        {
            AdventurerList.AddAnAdventurer(adventurerRank);
        }

        public override string GetPriceString()
        {
            return Price + " Gold";
        }
    }
}