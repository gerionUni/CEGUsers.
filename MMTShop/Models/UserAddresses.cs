using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CEGUsers
{
    public class UserAddresses
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [StringLength(250)]
        public string HouseNumber { get; set; }
        [StringLength(250)]
        public string PostCode { get; set; }


    }

}
