using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.DTOs
{
    public class CompanyDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
    }
}
