using System;

namespace InterviewTest.App
{
    public class Vegetable : IProduct
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

        public Vegetable(string name, int count, int unitPrice)
        {
            Id = Guid.NewGuid();
            HealthIndex = HealthIndex.Good;
            Name = name;
            Count = count;
            UnitPrice = unitPrice;
        }
    }
}