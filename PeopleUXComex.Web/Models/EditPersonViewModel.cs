using PeopleUXComex.Core.Entities;
using System.Collections.Generic;

namespace PeopleUXComex.Web.Models
{
    public class EditPersonViewModel
    {
        public Person Person { get; set; }
        public List<Address> Addresses { get; set; }
        public Address NewAddress { get; set; } = new Address();
    }
}
