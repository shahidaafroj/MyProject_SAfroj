using System;
using System.Collections.Generic;
using Repository_Domain;

namespace Repository_Pattern
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}
