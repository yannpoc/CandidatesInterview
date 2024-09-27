namespace InterviewTest.App
{
    public class Vegetable : Product
    {
        public Vegetable(string name, int count, int unitPrice)
            : base(name, count, unitPrice, HealthIndex.Good)
        {
        }
    }
}