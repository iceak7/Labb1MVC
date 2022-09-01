using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookBorrow> BookBorrows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId=1, 
                Title="Harry Potter",
                Author="J.K Rowling",
                NumberOfBooksInStock=5,
                TotalNumberOfBooks=7
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 2,
                Title = "Da Vinci-Koden",
                Author = "Dan Brown",
                NumberOfBooksInStock = 3,
                TotalNumberOfBooks = 4
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 3,
                Title = "Berättelsen om Narnia",
                Author = "C.S Lewis",
                NumberOfBooksInStock = 6,
                TotalNumberOfBooks = 7
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 4,
                Title = "Hungerspelen",
                Author = "Suzanne Collins",
                NumberOfBooksInStock = 10,
                TotalNumberOfBooks = 11
            });


            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                Name = "Anders Andersson",
                City = "Halmstad",
                Address = "Vägen 1",
                PhoneNr = "0733333333",
                ZipCode = "30291"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                Name = "Sven Svensson",
                City = "Stockholm",
                Address = "Vägen 10",
                PhoneNr = "0744444444",
                ZipCode = "60291"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 3,
                Name = "Göran Göransson",
                City = "Göteborg",
                Address = "Gatan 1",
                PhoneNr = "075555555",
                ZipCode = "40291"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 4,
                Name = "Karl Karlsson",
                City = "Borås",
                Address = "Gränden 1",
                PhoneNr = "07666666",
                ZipCode = "20291"
            });


            modelBuilder.Entity<BookBorrow>().HasData(new BookBorrow
            {
               BookBorrowId = 1,
               BookId=1,
               CustomerId=2,
               BorrowDate=new DateTime(2022, 08, 15, 08,00,00),
               ReturnLatestDate=new DateTime(2022, 09, 15,08,00,00),
               Returned=false
            });
            modelBuilder.Entity<BookBorrow>().HasData(new BookBorrow
            {
                BookBorrowId = 2,
                BookId = 1,
                CustomerId = 3,
                BorrowDate = new DateTime(2022, 08, 10, 08, 00, 00),
                ReturnLatestDate = new DateTime(2022, 09, 10, 08, 00, 00),
                Returned = false
            });

            modelBuilder.Entity<BookBorrow>().HasData(new BookBorrow
            {
                BookBorrowId = 3,
                BookId = 2,
                CustomerId = 1,
                BorrowDate = new DateTime(2022, 08, 25, 08, 00, 00),
                ReturnLatestDate = new DateTime(2022, 09, 25, 08, 00, 00),
                Returned = false
            });

            modelBuilder.Entity<BookBorrow>().HasData(new BookBorrow
            {
                BookBorrowId = 4,
                BookId = 4,
                CustomerId = 3,
                BorrowDate = new DateTime(2022, 08, 30, 08, 00, 00),
                ReturnLatestDate = new DateTime(2022, 09, 30, 08, 00, 00),
                Returned = false
            });

            modelBuilder.Entity<BookBorrow>().HasData(new BookBorrow
            {
                BookBorrowId = 5,
                BookId = 3,
                CustomerId = 4,
                BorrowDate = new DateTime(2022, 08, 24, 08, 00, 00),
                ReturnLatestDate = new DateTime(2022, 09, 24, 08, 00, 00),
                Returned = false
            });


            modelBuilder.Entity<BookBorrow>().HasData(new BookBorrow
            {
                BookBorrowId = 6,
                BookId = 4,
                CustomerId = 1,
                BorrowDate = new DateTime(2022, 07, 24, 08, 00, 00),
                ReturnLatestDate = new DateTime(2022, 08, 24, 08, 00, 00),
                Returned = true,
                ReturnedDate= new DateTime(2022, 08, 20, 08, 00, 00)
            });

            modelBuilder.Entity<BookBorrow>().HasData(new BookBorrow
            {
                BookBorrowId = 7,
                BookId = 3,
                CustomerId = 2,
                BorrowDate = new DateTime(2022, 07, 29, 08, 00, 00),
                ReturnLatestDate = new DateTime(2022, 08, 29, 08, 00, 00),
                Returned = true,
                ReturnedDate = new DateTime(2022, 08, 05, 08, 00, 00)
            });
        }
    }
}
