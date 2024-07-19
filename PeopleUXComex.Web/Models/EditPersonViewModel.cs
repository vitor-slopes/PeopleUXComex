using PeopleUXComex.Core.Entities;
using System.Collections.Generic;

namespace PeopleUXComex.Web.Models
{
    public class EditPersonViewModel
    {
        public Person Person { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public Address NewAddress { get; set; } = new Address();
    }
}
