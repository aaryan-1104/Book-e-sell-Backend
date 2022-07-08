﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models
{
    public class ListResponse<T> where T:class
    {
        public List<T> Results { get; set; }
        public int Totalrecords { get; set; }
    }
}
