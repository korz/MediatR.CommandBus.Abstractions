using MediatR.CommandBus.Abstractions.Contracts;
using System.Collections.Generic;

namespace MediatR.CommandBus.Abstractions.Infrastructure.Helpers
{
    public static class FakeData
    {
        public static IEnumerable<Customer> GetCustomers()
        {
            yield return new Customer
            {
                Id = 0,
                FirstName = "Adelia",
                LastName = "Kessler",
                Address = new Address { Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }
            };

            yield return new Customer
            {
                Id = 1,
                FirstName = "Melissa",
                LastName = "Labadie",
                Address = new Address { Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }
            };

            yield return new Customer
            {
                Id = 2,
                FirstName = "Gerard",
                LastName = "Gerhold",
                Address = new Address { Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }
            };

            yield return new Customer
            {
                Id = 3,
                FirstName = "Clemens",
                LastName = "Kassulke",
                Address = new Address { Street = "0584 Leffler Garden", City = "East Cathy", State = "KY", Zip = "05828" }
            };

            yield return new Customer
            {
                Id = 4,
                FirstName = "Cloyd",
                LastName = "Heaney",
                Address = new Address { Street = "2486 Graham Junction", City = "New Pietro", State = "AE", Zip = "66483" }
            };

            yield return new Customer
            {
                Id = 5,
                FirstName = "Magdalena",
                LastName = "Lynch",
                Address = new Address { Street = "17177 Parisian Lake", City = "Zaneton", State = "OK", Zip = "21861" }
            };

            yield return new Customer
            {
                Id = 6,
                FirstName = "Zoila",
                LastName = "Sanford",
                Address = new Address { Street = "3832 Hilll Vista", City = "Kaleymouth", State = "NV", Zip = "66815" }
            };

            yield return new Customer
            {
                Id = 7,
                FirstName = "Owen",
                LastName = "Treutel",
                Address = new Address { Street = "633 Savanah Plains", City = "New Jerodmouth", State = "AP", Zip = "52024" }
            };

            yield return new Customer
            {
                Id = 8,
                FirstName = "Christa",
                LastName = "Kessler",
                Address = new Address { Street = "54385 Gusikowski Crossroad", City = "Cristianhaven", State = "GU", Zip = "54364-8100" }
            };

            yield return new Customer
            {
                Id = 9,
                FirstName = "Dameon",
                LastName = "Lehner",
                Address = new Address { Street = "05407 Ward Trafficway", City = "South Jan", State = "AS", Zip = "81883-1106" }
            };
        }
    }
}
