using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewTest.App
{
	public class ProductStore:IProductStore
	{
		private readonly List<IProduct> _products = new List<IProduct>();
		public IEnumerable<IProduct> GetProducts()
		{
			return _products.ToList();
		}

		public ProductStore()
		{
			//NOTE: NO NEED TO CHANGE THIS; 
			_products.AddRange(new IProduct[]
			{
				new Fruit("Orange", 5,3),
				new Vegetable("Salad", 3,6)
			});
		}

		public void ap(IProduct product)
		{
			Thread.Sleep(5000);//DO NOT REMOVE; TO SIMULATE A BUGGY/SLOW SERVICE
			_products.Add(product);
			ProductAdded?.Invoke(product);
		}

		public void rp(Guid productId)
		{
			Thread.Sleep(5000);//DO NOT REMOVE; TO SIMULATE A BUGGY/SLOW SERVICE
			IProduct product = _products.FirstOrDefault(p => p.Id.Equals(productId));
			if (product != null)
			{
				_products.Remove(product);
				ProductRemoved?.Invoke(productId);
			}
		}

		public event Action<IProduct> ProductAdded;
		public event Action<Guid> ProductRemoved;
	}
}
