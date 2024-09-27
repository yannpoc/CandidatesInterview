namespace InterviewTest.App
{
    public class Fruit : Product
    {
        public Fruit(string name, int count, int unitPrice)
            : base(name, count, unitPrice, HealthIndex.Average)
        {
        }
    }
}