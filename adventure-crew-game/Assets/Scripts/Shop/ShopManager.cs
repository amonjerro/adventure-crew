using System;
using UnityEngine;

namespace Backend.IAP
{
    public class ShopManager : MonoBehaviour
    {
        public static ShopManager Instance { get; private set; }
        [SerializeField] private ShopProductConfig productConfig;
        [SerializeField] private AdventurerDisplay adventurers;

        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            var products = GetProducts();

            foreach (var product in products)
            {
                product.Init();
            }
        }

        public ShopProduct[] GetProducts()
        {
            return productConfig.Products;
        }

        private ShopProduct GetProductById(string id)
        {
            return productConfig.GetProductById(id);
        }
        
        public bool IsProductPurchased(string id)
        {
            return productConfig.IsProductPurchased(id);
        }
        
        public void TryPurchaseProduct(string id, Action<bool> onPurchase = null)
        {
            var product = GetProductById(id);
            product.OnPurchaseSuccessful(adventurers);
            
            onPurchase?.Invoke(true);
        }

        public void ResetPurchases()
        {
            var products = GetProducts();

            foreach (var product in products)
            {
                product.ResetPurchase();
            }
        }
    }
}
