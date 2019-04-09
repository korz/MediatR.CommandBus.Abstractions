namespace MediatR.CommandBus.Abstractions.Contracts
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; } = true;
        public Address Address { get; set; }
    }
}
