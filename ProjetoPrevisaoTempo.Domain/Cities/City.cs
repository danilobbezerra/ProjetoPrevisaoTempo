﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPrevisaoTempo.Domain.Cidades
{

    [ExcludeFromCodeCoverage]
    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public double Population { get; set; }
    }
}
