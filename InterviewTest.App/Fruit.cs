using System;

namespace InterviewTest.App
{
    public class Fruit : IProduct
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int UnitPrice { get; set; }

        public int TotalPrice
        {
            get { return UnitPrice * Count; }
        }

        public HealthIndex HealthIndex { get; }

        public Fruit(string name, int count, int unitPrice)
        {
            Id = Guid.NewGuid();
            HealthIndex = HealthIndex.Average;
            Name = name;
            Count = count;
            UnitPrice = unitPrice;
        }
    }
}