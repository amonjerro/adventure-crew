using Backend.IAP;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Test.IAP
{
    public class IAPDummyUI : MonoBehaviour
    {
        [SerializeField] private GameObject[] productsUI;

        private string _currentProductID;

        private void Start()
        {
            var products = IAPManager.Instance.GetProducts();

            for (var i = 0; i < products.Length; i++)
            {
                var product = products[i];
                var productUI = productsUI[i];

                if (productUI == null) continue;

                // Set product UI data
                // This is a quick way to do this don't do this in production.
                productUI.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = product.Name;
                productUI.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = product.Description;
                productUI.transform.Find("Price").GetComponent<TextMeshProUGUI>().text = product.Price;
                productUI.GetComponentInChildren<Button>().interactable = !product.Purchased;
            }
        }

        private void Update()
        {
            var products = IAPManager.Instance.GetProducts();

            for (var i = 0; i < products.Length; i++)
            {
                var product = products[i];
                var productUI = productsUI[i];

                // This is a quick way to do this don't do this in production.
                productUI.GetComponentInChildren<Button>().interactable = !product.Purchased;
            }
        }

        public void SetCurrentProductID(string id)
        {
            _currentProductID = id;
        }

        public void TryPurchaseProduct()
        {
            // Purchase logic
            IAPManager.Instance.TryPurchaseProduct(_currentProductID,
                success => { Debug.Log(success ? $"Purchased product with ID: {_currentProductID}" : $"Failed to purchase product with ID: {_currentProductID}"); });
        }

        public void ResetPurchases()
        {
            IAPManager.Instance.ResetPurchases();
        }
    }
}