using Repository_Domain;
using Repository_Pattern;
using System;

namespace LibraryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryMenu();
        }

        static void LibraryMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nLibrary Menu:");
                Console.WriteLine("1. Book Operations");
                Console.WriteLine("2. Customer Operations");
                Console.WriteLine("3. Exit");

                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BookMenu();
                        break;
                    case "2":
                        CustomerMenu();
                        break;
                    case "3":
                        Console.WriteLine("Thank you! Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please choose 1, 2, or 3.");
                        break;
                }
            }
        }

        static void BookMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nBook Operations:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4.To Get Book Information");
                Console.WriteLine("5. Return to Main Menu");

                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        {
                            Book bk = new Book();
                            Console.Write("Book Name : ");
                            bk.BookName = Console.ReadLine();
                            Console.Write("Author Name : ");
                            bk.AuthorName = Console.ReadLine();
                            Console.Write("Edition No. : ");
                            bk.Edition = Console.ReadLine();
                            Console.Write("Phone No. : ");
                            bk.CellPhoneNo = Console.ReadLine();
                            Console.Write("ISBN (5 digits) : ");
                            bk.ISBN = Console.ReadLine();

                            Console.Clear();
                            IBookRepository source = RepositoryFactory.Create<IBookRepository>(ContextTypes.XMLSource);
                            var existingBook = source.GetByISBN(bk.ISBN);
                            if (existingBook != null)
                            {
                                Console.WriteLine("A book with this ISBN already exists.");
                            }
                            else
                            {
                                try
                                {
                                    source.Insert(bk);
                                    Console.WriteLine("Book Inserted Successfully...");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error:{ex.Message}");
                                }
                            }
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        UpdateBook();
                        {
                            Console.Write("Enter the ISBN (5 digits) of the book to update: ");
                            string isbn = Console.ReadLine();

                            var source = RepositoryFactory.Create<IBookRepository>(ContextTypes.XMLSource);
                            var existingBook = source.GetByISBN(isbn);
                            if (existingBook != null)
                            {
                                Console.WriteLine($"Current Book Name : {existingBook.BookName}");
                                Console.Write("New Book Name : ");
                                string newBookName = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newBookName)) existingBook.BookName = newBookName;
                                Console.WriteLine($"Current Author Name : {existingBook.AuthorName}");
                                Console.Write("New Author Name : "); string newAuthorName = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newAuthorName)) existingBook.AuthorName = newAuthorName;
                                Console.WriteLine($"Current Edition No. : {existingBook.Edition}");
                                Console.Write("New Edition No. : "); string newEditionNo = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newEditionNo)) existingBook.Edition = newEditionNo;
                                Console.WriteLine($"Current Cell Phone No. : {existingBook.CellPhoneNo}");
                                Console.Write("New Cell Phone No. : "); string newCellPhoneNo = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newCellPhoneNo)) existingBook.CellPhoneNo = newCellPhoneNo;
                                if (source.UpdateByISBN(existingBook))
                                {
                                    Console.WriteLine("Book information updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to update book information.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Book not found.");
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        DeleteBook();
                        {
                            Console.Write("Enter the ISBN (5 digits) of the book to delete: ");
                            string isbn = Console.ReadLine();

                            var source = RepositoryFactory.Create<IBookRepository>(ContextTypes.XMLSource);
                            if (source.DeleteByISBN(isbn))
                            {
                                Console.WriteLine("Book deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to delete book.");
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case "4":
                        BookInformation();
                        {
                            var bookSource = RepositoryFactory.Create<IBookRepository>(ContextTypes.XMLSource);
                            var books = bookSource.GetAll();
                            Console.WriteLine();
                            Console.WriteLine("=============Book Information===========");
                            foreach (var book in books)
                            {
                                Console.WriteLine(book.BookName + ", " + book.AuthorName + ", " + book.Edition + ", " + book.CellPhoneNo + ", " + book.ISBN);
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please choose 1, 2, 3, or 4.");
                        break;
                }
            }
        }

        static void CustomerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nCustomer Operations:");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Update Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. To Get Customer Information");
                Console.WriteLine("5. Return to Main Menu");

                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        {
                            Customer cust = new Customer();
                            Console.Write("Customer ID : ");
                            cust.CustomerID = int.Parse(Console.ReadLine());
                            Console.Write("Customer Name : ");
                            cust.Name = Console.ReadLine();
                            Console.Write("Customer Email : ");
                            cust.Email = Console.ReadLine();
                            Console.Write("Customer Phone Number : ");
                            cust.PhoneNumber = Console.ReadLine();
                            Console.Write("Customer Address : ");
                            cust.Address = Console.ReadLine();
                            Console.Clear();

                            var customerSource = RepositoryFactory.Create<ICustomerRepository>(ContextTypes.XMLSource);
                            try
                            {
                                customerSource.Insert(cust);
                            }
                            catch (Exception ex)
                            {
                                Console.Write(ex);
                                Console.ReadKey();
                                continue;
                            }
                        }
                        break;
                  



                    case "2":
                        UpdateCustomer();
                        {
                            Console.Write("Enter the CustomerID of the Customer to update: ");
                            int customerid = int.Parse(Console.ReadLine());

                            var customersource = RepositoryFactory.Create<ICustomerRepository>(ContextTypes.XMLSource);
                            var existingCustomer = customersource.GetByCustomerID(customerid);
                            if (existingCustomer != null)
                            {
                                Console.WriteLine($"Current Customer Name : {existingCustomer.Name}");
                                Console.Write("New Customer Name : ");
                                string newCustomerName = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newCustomerName)) existingCustomer.Name = newCustomerName;
                                Console.WriteLine($"Customer Email : {existingCustomer.Email}");
                                Console.Write("New Customer Email : "); string customerEmail = Console.ReadLine();
                                if (!string.IsNullOrEmpty(customerEmail)) existingCustomer.Email = customerEmail;
                                Console.WriteLine($"Current Phone Number. : {existingCustomer.PhoneNumber}");
                                Console.Write("New Phone Number. : "); string newPhoneNumber = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newPhoneNumber)) existingCustomer.PhoneNumber = newPhoneNumber;
                                Console.WriteLine($"Current Customer Address. : {existingCustomer.Address}");
                                Console.Write("New Customer Address. : "); string newCustomeraddress = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newCustomeraddress)) existingCustomer.Address = newCustomeraddress;
                                if (customersource.UpdateByCustomerID(existingCustomer))
                                {
                                    Console.WriteLine("Customer information updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to update customer information.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Customer not found.");
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;

                    case "3":
                        DeleteCustomer();
                        {
                            Console.Write("Enter the Customer ID to delete: ");
                            int customerId = int.Parse(Console.ReadLine());
                            var customerSource = RepositoryFactory.Create<ICustomerRepository>(ContextTypes.XMLSource); 
                            if (customerSource.DeleteByCustomerID(customerId))
                            {
                                Console.WriteLine("Customer deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to delete customer.");
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case "4":
                        CustomerInformation();
                        {
                            var customerSource = RepositoryFactory.Create<ICustomerRepository>(ContextTypes.XMLSource);
                            var customers = customerSource.GetAll();
                            Console.WriteLine();
                            Console.WriteLine("=============Customer Information===========");
                            foreach (var customer in customers)
                            {
                                Console.WriteLine(customer.CustomerID + " : " + customer.Name + ", " + customer.Email + ", " + customer.PhoneNumber + ", " + customer.Address);
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please choose 1, 2, 3, or 4.");
                        break;
                }
            }
        }

        // Implement these methods as per your requirements
        static void AddBook()
        {
            Console.WriteLine("Adding a new book...");
            // Implement your logic here
        }

        static void UpdateBook()
        {
            Console.WriteLine("Updating book information...");
            // Implement your logic here
        }

        static void DeleteBook()
        {
            Console.WriteLine("Deleting a book...");
            // Implement your logic here
        }
        static void BookInformation()
        {
            Console.WriteLine("Book Information...");
        }

        static void AddCustomer()
        {
            Console.WriteLine("Adding a new customer...");
            // Implement your logic here
        }

        static void UpdateCustomer()
        {
            Console.WriteLine("Updating customer information...");
            // Implement your logic here
        }

        static void DeleteCustomer()
        {
            Console.WriteLine("Deleting a customer...");
            // Implement your logic here
        }
        static void CustomerInformation()
        {
            Console.WriteLine("Customer Information....");
        }
    }
}

