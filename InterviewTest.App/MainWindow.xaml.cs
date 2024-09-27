using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InterviewTest.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<IProduct> _products = [];
        private readonly IProductStore _productStore;

        public MainWindow()
        {
            InitializeComponent();
            _productStore = ServiceProvider.Instance.ProductStore;
            _products.AddRange(_productStore.GetProducts());
            RefreshProducts();
            _productStore.ProductAdded += ProductStore_ProductAdded;
            _productStore.ProductRemoved += ProductStore_ProductRemoved;
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var name = _name.Text;
            int unitPrice;
            int quantity;
            IProduct p;
            if (!string.IsNullOrEmpty(_type.Text) && int.TryParse(_unitprice.Text, out unitPrice) && int.TryParse(_quantity.Text, out quantity))
            {
                if (_type.Text == "Vegetable")
                {
                    p = new Vegetable(name, quantity, unitPrice);
                }
                else
                {
                    p = new Fruit(name, quantity, unitPrice);
                }

                await Task.Run(() => _productStore.AddProduct(p));
            }
        }

        private void RefreshProducts()
        {
            Dispatcher.Invoke(() =>
            {
                _productList.Items.Clear();
                foreach (IProduct product in _products)
                {
                    _productList.Items.Add(product);
                }
            });
        }

        private void Integer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }

        private void ProductStore_ProductRemoved(Guid obj)
        {
            IProduct possibleProduct = _products.FirstOrDefault(p => p.Id == obj);
            if (possibleProduct != null)
            {
                _products.Remove(possibleProduct);
                RefreshProducts();
            }
        }

        private void ProductStore_ProductAdded(IProduct obj)
        {
            _products.Add(obj);
            RefreshProducts();
        }

        private async void CheckStoreAvailabilityButton_Click(object sender, RoutedEventArgs e)
        {
            var checkers = new List<ProductAvailabilityChecker>();
            var tasks = new List<Task>();

            // Make a copy of the product now. Shallow copy ok because member of product are value types.
            var products_ = _products.ToList();
            foreach (IProduct p in products_)
            {
                var productAvailabilityChecker = new ProductAvailabilityChecker(p);
                checkers.Add(productAvailabilityChecker);

                tasks.Add(Task.Run(productAvailabilityChecker.CheckIfAvailable));
            }

            await Task.WhenAll(tasks);

            var sb = new StringBuilder();
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