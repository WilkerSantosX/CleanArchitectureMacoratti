﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    //Classe anêmica
    //sealed não pode ser herdada
    public sealed class User : BaseEntity
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
