using System;
using UnityEngine;

namespace Backend.IAP
{
    public class IAPManager : MonoBehaviour
    {
        public static IAPManager Instance { get; private set; }
        public GameObject IAPUI;
        [SerializeField] private IAPProductConfig productConfig;

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

        public IAPProduct[] GetProducts()
        {
            return productConfig.Products;
        }

        private IAPProduct GetProductById(string id)
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
            product.OnPurchaseSuccessful();
            
            onPurchase?.Invoke(true);
        }

        public void ToggleVisibility()
        {
            IAPUI.SetActive(!IAPUI.activeInHierarchy);
        }
    }
}
