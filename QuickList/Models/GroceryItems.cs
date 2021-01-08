using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuickList.Models
{
    public class GroceryItems
    {
        [Key]
        public int ItemId { get; set; }


        [ForeignKey("GroceryList")]
        public int GroceryListId { get; set; }
        public GroceryList GroceryList { get; set; }


        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product product { get; set; }


        public double RealCost { get; set; }
    }
}
