namespace InterviewTest.App
{
    public class ServiceProvider
    {
        public static ServiceProvider Instance { get; } = new ServiceProvider();
        public IProductStore ProductStore { get; }

        private ServiceProvider()
        {
            ProductStore = new ProductStore();
        }
    }
}