using System;
using System.Collections.Generic;

namespace InterviewTest.App
{
    public interface IProductStore
    {
        IEnumerable<IProduct> GetProducts();

        IEnumerable<string> GetProductTypes();

        void AddProduct(IProduct product);

        void RemoveProduct(Guid productId);

        //Let's assume we cannot update a product
        event Action<IProduct> ProductAdded;

        event Action<Guid> ProductRemoved;
    }
}