﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoanManagement.WebSite.Models
{
    public class CustomerItem
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }
    }
}