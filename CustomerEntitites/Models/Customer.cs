using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerEntities.Models
{
    public class Customer
    {
        public int Id { get; set; }
      //  public string Name { get; set; }
        public int AddressId { get; set; }

        public string FirstName { get; set; }
        public string LastName {get;set;}
    }
}
