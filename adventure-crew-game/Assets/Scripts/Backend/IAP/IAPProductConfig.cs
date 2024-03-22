using System.Linq;
using UnityEngine;

namespace Backend.IAP
{
    [CreateAssetMenu(fileName = "IAP Product Config", menuName = "IAP/Product Config", order = 0)]
    public class IAPProductConfig : ScriptableObject
    {
        [SerializeField] private IAPProduct[] products;

        public IAPProduct[] Products => products;

        internal IAPProduct GetProductById(string id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        internal bool IsProductPurchased(string id)
        {
            var product = GetProductById(id);
            return product?.Purchased ?? false;
        }
    }
}