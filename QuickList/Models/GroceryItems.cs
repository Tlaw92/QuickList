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
        public string City { get; set; }

        public string Date { get; set; }

        public double Price { get; set; }

        [Key]
        public int ItemId { get; set; }
        public string Title { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("GroceryList")]
        public int GroceryListId { get; set; }
        public GroceryList GroceryList { get; set; }



    }
}
