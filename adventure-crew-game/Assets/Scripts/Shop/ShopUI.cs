using Backend.IAP;
using Shop;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Test.IAP
{
    public abstract class ShopUI<T> : MonoBehaviour where T : Product
    {
        [SerializeField, Space] private ProductConfig<T> productConfig;
        [SerializeField] private GameObject purchasePopup;
        [SerializeField] private GameObject[] productsUI;

        private T _currentProduct;

        private void Start()
        {
            var products = productConfig.Products;

            for (var i = 0; i < productsUI.Length; i++)
            {
                var product = products[i];
                var productUI = productsUI[i];

                if (productUI == null) continue;

                // Set product UI data
                // This is a quick way to do this don't do this in production.
                productUI.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = product.Name;
                productUI.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = product.Description;
                productUI.transform.Find("Price").GetComponent<TextMeshProUGUI>().text = product.GetPriceString();
                productUI.transform.Find("Purchase Button").GetComponent<Button>().onClick.AddListener(() => SetCurrentProductID(product.ID));
            }
        }

        private void SetCurrentProductID(string id)
        {
            _currentProduct = productConfig.GetProductById(id);
            purchasePopup.SetActive(true);
        }

        public void TryPurchaseProduct()
        {
            if (_currentProduct != null)
            {
                if (!_currentProduct.TryPurchaseProduct(out var errorMessage))
                {
                    ErrorPopup.ShowError(errorMessage);
                    Debug.Log($"Failed to purchase product with ID: {_currentProduct.ID}\t Error: {errorMessage}");
                }
            }
            else
                ErrorPopup.ShowError("No product selected or product not found.");
            
            _currentProduct = null;
        }
    }
}