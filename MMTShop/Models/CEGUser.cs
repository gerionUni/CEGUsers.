using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CEGUsers
{
    public class CEGUser
    {
        [Key]
        public int ID { get; set; }
        public string Firstname { get; set; }
        [StringLength(250)]
        public string Surname { get; set; }
        [StringLength(250)]
        public DateTime DOB { get; set; }
        public List<UserAddresses> UserAddress { get; set; }
       
    }


}
