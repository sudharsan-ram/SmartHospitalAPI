using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.API.Patient.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public int age { get; set; }
        public string address { get; set; }
    }
}
