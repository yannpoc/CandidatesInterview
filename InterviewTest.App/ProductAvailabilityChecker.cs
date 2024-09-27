using System.Threading;

namespace InterviewTest.App
{
    public class ProductAvailabilityChecker
    {
        public IProduct Product { get; }

        public ProductAvailabilityChecker(IProduct product)
        {
            Product = product;
        }

        public void CheckIfAvailable()
        {
            Thread.Sleep(5000);//Let us to check
            Result = true;
        }

        public bool Result { get; private set; }
    }
}