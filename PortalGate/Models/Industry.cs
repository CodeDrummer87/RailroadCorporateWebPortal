﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGate.Models
{
    public class Industry
    {
        [Key]
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string FullTitle { get; set; }
    }
}
