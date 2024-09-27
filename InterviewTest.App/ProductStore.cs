using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace InterviewTest.App
{
    public class ProductStore : IProductStore
    {
        private readonly object _instanceLock = new();
        private readonly List<IProduct> _products = [];
        private readonly List<string> _productTypes = [];

        public IEnumerable<IProduct> GetProducts()
        {
            return _products.ToList();
        }

        public IEnumerable<string> GetProductTypes()
        {
            return _productTypes;
        }

        public ProductStore()
        {
            //NOTE: NO NEED TO CHANGE THIS;
            _products.AddRange(
            [
                new Fruit("Orange", 5,3),
                new Vegetable("Salad", 3,6)
            ]);

            _productTypes = ["Fruit", "Vegetable", /*"Bread"*/];
        }

        public void AddProduct(IProduct product)
        {
            lock (_instanceLock)
            {
                Thread.Sleep(5000);//DO NOT REMOVE; TO SIMULATE A BUGGY/SLOW SERVICE
                _products.Add(product);
                ProductAdded?.Invoke(product);
            }
        }

        public void RemoveProduct(Guid productId)
        {
            lock (_instanceLock)
            {
                Thread.Sleep(5000);//DO NOT REMOVE; TO SIMULATE A BUGGY/SLOW SERVICE
                IProduct product = _products.FirstOrDefault(p => p.Id.Equals(productId));
                if (product != null)
                {
                    _products.Remove(product);
                    ProductRemoved?.Invoke(productId);
                }
            }
        }

        public event Action<IProduct> ProductAdded;

        public event Action<Guid> ProductRemoved;
    }
}