namespace Refactoring_Example.Models
{
    public class Invoice
    {
        public Invoice(string customer, Performance[] performances)
        {
            Customer = customer;
            Performances = performances;
        }

        public string Customer { get; }
        public Performance[] Performances { get; }
    }
}