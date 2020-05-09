﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace exxxxxxx.Models
{
    public class PriceAttribute : ValidationAttribute
    {
        public double MinimumPrice { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null) { return false; }

            if((decimal)value < (decimal)MinimumPrice) { return false; }

            return true;
        }
    }
}
