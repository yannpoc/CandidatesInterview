using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewTest.App.RemoteWorkerSimulator_DO_NOT_TOUCH
{
	//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	//This class simulate another worker that use the same repository than you.
	//Assume you don't have access to this worker, you cannot prevent its execution or change what it is doing. 
	//This class should remains unchanged
	//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	#region DO NOT TOUCH
	public class RemoteProductWorkerSimulator
	{
		private const int DELAY_BETWEEN_TASKS = 5000;
		private IProductStore _productStore;
		private CancellationToken _token;
		private Random _random = new Random();

		private String[] _fruitsName = new[]
		{
			"Coconut",
			"Bananaaaaaaaa",
			"Cherry",
			"Apple",
			"Peach",
			"Raspberry"
		};



		public RemoteProductWorkerSimulator()
		{
			_productStore = ServiceProvider.Instance.ProductStore;
		}


		public Task Run(CancellationToken token)
		{
			_token = token;
			return Task.Factory.StartNew(RunRemoteSimulator,token);
		}

		private void RunRemoteSimulator()
		{
			//First wait
			Thread.Sleep(20000);

			while (!_token.IsCancellationRequested)
			{
				Thread.Sleep(DELAY_BETWEEN_TASKS);
				_productStore.ap(new Fruit(_fruitsName[_random.Next(_fruitsName.Length)], _random.Next(10),_random.Next(5)));
				Thread.Sleep(DELAY_BETWEEN_TASKS);
				IEnumerable<IProduct> products = _productStore.GetProducts().ToList();
				if (products.Any())
				{
					IProduct product = products.Skip(_random.Next(0, products.Count() - 1)).First();
					_productStore.rp(product.Id);
				}
			}
		}
	}
	#endregion
}
