using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Repository_Domain;
using Repository_Source;

namespace Repository_Pattern
{
    public class XMLRepositoryBase<TContext, TEntity, TKey> : IRepository<TEntity, TKey>
        where TContext : XMLSet<TEntity>
        where TEntity : class
    {
        private XMLSet<TEntity> m_context;

        public XMLRepositoryBase(string fileName)
        {
            m_context = new XMLSet<TEntity>(fileName);
        }
        public bool Delete(TKey id)
        {
            try
            {
                List<IEntity<TKey>> items = m_context.Data as List<IEntity<TKey>>;
                items.Remove(items.First(f => f.BookID.Equals(id)));
                m_context.Data = items as ICollection<TEntity>;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var list = m_context.Data.AsQueryable().Where(predicate).ToList();
                return list as ICollection<TEntity>;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TEntity Get(TKey id)
        {
            try
            {
                List<IEntity<TKey>> items = m_context.Data as List<IEntity<TKey>>;
                return items.FirstOrDefault(f => f.BookID.Equals(id)) as TEntity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ICollection<TEntity> GetAll()
        {
            return m_context.Data;
        }

        public TKey Insert(TEntity model)
        {
            var list = m_context.Data; list.Add(model); m_context.Data = list;
            return default(TKey);
        }

        public bool Remove(TKey id)
        {
            return Delete(id);
        }

        public bool Update(TEntity model)
        {
            try
            {
                IEntity<TKey> imodel = model as IEntity<TKey>;
                List<IEntity<TKey>> items = m_context.Data as List<IEntity<TKey>>;
                items.Remove(items.FirstOrDefault(f => f.BookID.Equals(imodel.BookID)));
                items.Add(imodel);
                m_context.Data = items as ICollection<TEntity>;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TEntity GetByISBN(string isbn)
        {
            try
            {
                var items = m_context.Data as List<Book>;
                return items.FirstOrDefault(f => f.ISBN == isbn) as TEntity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteByISBN(string isbn)
        {
            try
            {
                List<Book> items = m_context.Data as List<Book>;
                var bookToDelete = items.First(f => f.ISBN == isbn);
                items.Remove(bookToDelete);
                m_context.Data = items as ICollection<TEntity>;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateByISBN(TEntity model)
        {
            try
            {
                Book bookModel = model as Book;
                List<Book> items = m_context.Data as List<Book>;
                var existingBook = items.FirstOrDefault(f => f.ISBN == bookModel.ISBN);
                if (existingBook != null)
                {
                    items.Remove(existingBook);
                    items.Add(bookModel);
                    m_context.Data = items as ICollection<TEntity>;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteByCustomerID(string id)
        {
            try
            {
                List<Customer> items = m_context.Data as List<Customer>;
                var CustomerToDelete = items.First(f => f.CustomerID.Equals(id));
                items.Remove(CustomerToDelete);
                m_context.Data = items as ICollection<TEntity>;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateByCustomerID(TEntity model)
        {
            try
            {
                Customer customermodel = model as Customer;
                List<Customer> items = m_context.Data as List<Customer>;
                var existingCustomer = items.FirstOrDefault(f => f.CustomerID == customermodel.CustomerID);
                if (existingCustomer != null)
                {
                    items.Remove(existingCustomer);
                    items.Add(customermodel);
                    m_context.Data = items as ICollection<TEntity>;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public TEntity GetByCustomerID(int customerid)
        {
            try
            {
                var items = m_context.Data as List<Customer>;
                return items.FirstOrDefault(f => f.CustomerID == customerid) as TEntity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteByCustomerID(int customerID)
        {
            try
            {
                List<Customer> customers = m_context.Data as List<Customer>;
                if (customers == null)
                {
                    Console.WriteLine("Customers list is null.");
                    return false;
                }

                var customerToDelete = customers.FirstOrDefault(c => c.CustomerID.Equals(customerID));
                if (customerToDelete != null)
                {
                    customers.Remove(customerToDelete);
                    m_context.Data = customers as ICollection<TEntity>;
                    return true;
                }
                Console.WriteLine("Customer not found.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
        }

    }
}
