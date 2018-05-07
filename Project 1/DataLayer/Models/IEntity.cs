﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
        public abstract class BaseEntity
        {
            DateTime Created { get; set; }
            DateTime? Modified { get; set; }
        }
    
}
