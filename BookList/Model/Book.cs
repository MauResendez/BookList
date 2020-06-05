﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Model
{
    public class Book
    {
        [Key] // Will create a unique ID value for us
        public int Id { get; set; }

        [Required] // Name can't be null
        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }
    }
}
