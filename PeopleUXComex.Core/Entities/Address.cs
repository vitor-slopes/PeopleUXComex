using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleUXComex.Core.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string CEP { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PersonId { get; set; }
    }
}
