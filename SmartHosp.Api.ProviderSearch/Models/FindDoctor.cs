using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.Api.ProviderSearch.Models
{
    public class FindDoctor
    {
        public int Id { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string Specialty { get; set; }
    }
}
