using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PeopleUXComex.Core.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
