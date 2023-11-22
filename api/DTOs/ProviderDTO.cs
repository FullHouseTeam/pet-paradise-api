using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class ProviderDTO
    { 
        public int ProviderID { get; set; }

        public string Name { get; set; }= string.Empty;

        public string Nationality { get; set; }= string.Empty;
    }
}