using System;
using UnityEngine;

namespace Backend.IAP
{
    [Serializable]
    public class IAPProduct
    {
        [SerializeField] private string id;
        [Space, SerializeField] private string name;
        [SerializeField, Multiline] private string description;
        [Space, SerializeField] private string price;

        public string Id => id;
        public string Name => name;
        public string Description => description;
        public string Price => price;
        public bool Purchased { get; private set; }

        public void Init()
        {
            Purchased = PlayerPrefs.GetInt(id, 0) == 1;
        }

        internal void OnPurchaseSuccessful()
        {
            // Purchase logic
            Purchased = true;
            PlayerPrefs.SetInt(id, 1);
        }
    }
}