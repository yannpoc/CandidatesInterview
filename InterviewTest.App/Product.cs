using System;

namespace InterviewTest.App
{
    public class Product : IProduct
    {
        public Guid Id { get; }
        public string Name { get; }
        public int Count { get; }
        public int UnitPrice { get; }
        public int TotalPrice => UnitPrice * Count;
        public HealthIndex HealthIndex { get; }

        public Product(string name, int count, int unitPrice, HealthIndex healthIndex)
        {
            Id = Guid.NewGuid();
            HealthIndex = healthIndex;
            Name = name;
            Count = count;
            UnitPrice = unitPrice;
        }
    }
}