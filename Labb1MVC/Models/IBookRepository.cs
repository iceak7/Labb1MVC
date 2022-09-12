﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
    }
}
