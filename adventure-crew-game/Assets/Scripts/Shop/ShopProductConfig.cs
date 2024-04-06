using System.Linq;
using UnityEngine;

namespace Backend.IAP
{
    [CreateAssetMenu(fileName = "IAP Product Config", menuName = "IAP/Product Config", order = 0)]
    public class ShopProductConfig : ScriptableObject
    {
        [SerializeField] private ShopProduct[] products;

        public ShopProduct[] Products => products;

        internal ShopProduct GetProductById(string id)
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