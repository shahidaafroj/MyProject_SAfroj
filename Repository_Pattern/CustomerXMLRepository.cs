using System;
using Repository_Domain;
using Repository_Source;

namespace Repository_Pattern
{
    public class CustomerXMLRepository : XMLRepositoryBase<XMLSet<Customer>, Customer, int>, ICustomerRepository
    {
        public CustomerXMLRepository() : base("CustomerInformation.xml")
        {
        }
    }
}
