﻿using System;
using UnityEngine;

namespace Backend.IAP
{
    [Serializable]
    public class ShopProduct
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

        internal void Init()
        {
            Purchased = PlayerPrefs.GetInt(id, 0) == 1;
        }

        internal void OnPurchaseSuccessful(AdventurerDisplay adventurers)
        {
            if(id.Remove(id.Length - 1, 1) == "Contract") { adventurers.Generate(); }
            else if (id.Remove(id.Length - 1, 1) == "Product") { }
            // Purchase logic
            Purchased = true;
            //PlayerPrefs.SetInt(id, 1);
        }
        
        internal void ResetPurchase()
        {
            Purchased = false;
            PlayerPrefs.SetInt(id, 0);
        }
    }
}