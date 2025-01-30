using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository_Domain;
using Repository_Source;

namespace Repository_Pattern
{
    public class BookXMLRepository : XMLRepositoryBase<XMLSet<Book>, Book, int>, IBookRepository
    {
        public BookXMLRepository() : base("BookInformation.xml")
        {
        }
    }
}
