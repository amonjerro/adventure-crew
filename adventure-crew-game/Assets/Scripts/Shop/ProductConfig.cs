using System.Linq;
using Shop;
using UnityEngine;

namespace Backend.IAP
{
    public abstract class ProductConfig<T> : ScriptableObject where T : Product
    {
        [SerializeField] private T[] products;

        public T[] Products => products;
        
        internal T GetProductById(string id)
        {
            return products.FirstOrDefault(product => product.ID == id);
        }
    }
}