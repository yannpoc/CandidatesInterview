using System;

namespace InterviewTest.App
{
    public interface IProduct
    {
        Guid Id { get; }
        string Name { get; }
        int Count { get; }
        int UnitPrice { get; }
        int TotalPrice { get; }
        HealthIndex HealthIndex { get; }
    }
}