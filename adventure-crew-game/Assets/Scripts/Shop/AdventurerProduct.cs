using System;
using Backend;
using UnityEngine;

namespace Shop
{
    [Serializable]
    public class AdventurerProduct : Product
    {
        [SerializeField] private Adventurer.Rank adventurerRank;
        public override bool TryPurchaseProduct()
        {
            if (!CurrencySystem.RemoveCoins((int)Price))
            {
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