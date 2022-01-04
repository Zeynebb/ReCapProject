using Core.Entities;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    //[Table("Customers")]
    //[NotMapped]
    public class Customer: User, IEntity
    {
        public string CompanyName{ get; set; }



    }
}
