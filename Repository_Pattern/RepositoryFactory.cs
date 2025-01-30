
using System;

namespace Repository_Pattern
{
    public static class RepositoryFactory
    {
        public static TRepository Create<TRepository>(ContextTypes ctype) where TRepository : class
        {
            if (typeof(TRepository) == typeof(IBookRepository))
            {
                return new BookXMLRepository() as TRepository;
            }
            else if (typeof(TRepository) == typeof(ICustomerRepository))
            {
                return new CustomerXMLRepository() as TRepository;
            }
            return null;
        }
    }
}

