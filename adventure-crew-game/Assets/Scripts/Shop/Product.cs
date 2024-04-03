using System;
using System.Globalization;
using UnityEngine;

namespace Shop
{
    [Serializable]
    public abstract class Product
    {
        [SerializeField] private string id;
        [SerializeField] private string name;
        [SerializeField] private string description;
        [SerializeField] private float price;

        public string ID => id;
        public string Name => name;
        public string Description => description;
        public float Price => price;

        public abstract bool TryPurchaseProduct(out string errorMessage);
        public abstract void OnPurchaseSuccessful();

        public virtual void OnPurchaseFailed()
        {
            Debug.Log($"{id} Purchase Unsuccessful");
        }

        public virtual string GetPriceString()
        {
            return price.ToString(CultureInfo.InvariantCulture);
        }
    }
}