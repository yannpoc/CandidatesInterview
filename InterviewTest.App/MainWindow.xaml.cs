using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InterviewTest.App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly List<IProduct>  _products = new List<IProduct>();
		private readonly IProductStore _productStore;

		public MainWindow()
		{
			InitializeComponent();
			_productStore = ServiceProvider.Instance.ProductStore;
			_products.AddRange(_productStore.GetProducts());
			RefreshProducts();
			_productStore.ProductAdded += _productStore_ProductAdded;
			_productStore.ProductRemoved += _productStore_ProductRemoved;	
			
		}
		private void _unitprice_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex(@"^\d+$");
			e.Handled = !regex.IsMatch(e.Text);
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			String name = _name.Text;
			int up ;
			int qty ;
			IProduct p;
			if (!String.IsNullOrEmpty(_type.Text) && int.TryParse(_unitprice.Text, out up)  && int.TryParse(_quantity.Text,out qty ))
			{
				if (_type.Text == "Vegetable")
				{
					p = new Vegetable(name, qty, up);
				}
				else
				{

					p = new Fruit(name, qty, up);
				}
				_productStore.ap(p);
			}
		}

		private void RefreshProducts()
		{
			_productList.Items.Clear();
			foreach (IProduct product in _products)
			{
				_productList.Items.Add(product);
			}
		}

		private void _quantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex(@"^\d+$");
			e.Handled =!regex.IsMatch(e.Text);
		}


		private void _productStore_ProductRemoved(Guid obj)
		{
			IProduct possibleProduct = _products.FirstOrDefault(p => p.Id == obj);
			if (possibleProduct != null)
			{
				_products.Remove(possibleProduct);
				RefreshProducts();
			}
		}

		private void _productStore_ProductAdded(IProduct obj)
		{
			_products.Add(obj);
			RefreshProducts();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			List< ProductAvailabilityChecker > checkers = new List<ProductAvailabilityChecker>();
			List<Thread> t = new List<Thread>();
			foreach (IProduct p in _products)
			{
				ProductAvailabilityChecker productAvailabilityChecker = new ProductAvailabilityChecker(p);
				checkers.Add(productAvailabilityChecker);
				Thread thread = new Thread(productAvailabilityChecker.CheckIfAvailable);
				t.Add(thread);
				thread.Start();
			}
			foreach (Thread thread in t)
			{
				thread.Join();
			}

			StringBuilder sb = new StringBuilder();
			bool anyError = false;
			foreach (ProductAvailabilityChecker checker in checkers)
			{
				if (!checker.Result)
				{
					anyError = true;
					sb.AppendLine("The product " + checker.Product.Name + " is not available");
				}
			}
			if (!anyError)
			{
				MessageBox.Show(this, "Everything is available.");
			}
			else
			{
				MessageBox.Show(this, sb.ToString());
			}
		}
	}
}
