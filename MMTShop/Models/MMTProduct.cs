using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MMTShop
{
    public class MMTProduct
    {
        [Key]
        public int Id { get; set; }
        public int SKU { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        //made featured a bool on product level not category level
        //in order to have more flexibility in the future
        public bool Featured { get; set; }

        public MMTProductCategory Category { get; set; }
       
    }

    public class MMTProductCategory
    {
        [Key]
        public string Name { get; set; }
    }
}
