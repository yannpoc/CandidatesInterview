using System;

namespace InterviewTest.App
{
    public interface IProduct
    {
        Guid Id { get; }
        string Name { get; set; }
        int Count { get; set; }
        int UnitPrice { get; set; }
        int TotalPrice { get; }
        HealthIndex HealthIndex { get; }
    }
}