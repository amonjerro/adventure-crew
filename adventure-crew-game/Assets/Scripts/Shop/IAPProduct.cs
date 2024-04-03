using System;
using Backend;
using UnityEngine;

namespace Shop
{
    [Serializable]
    public class IAPProduct : Product
    {
        [SerializeField] private int coinsToGive;
        public override bool TryPurchaseProduct(out string errorMessage)
        {
            errorMessage = "";
            OnPurchaseSuccessful();
            return true;
        }

        public override void OnPurchaseSuccessful()
        {
            CurrencySystem.AddCoins(coinsToGive);
        }

        public override string GetPriceString()
        {
            return base.GetPriceString() + " $";
        }
    }
}