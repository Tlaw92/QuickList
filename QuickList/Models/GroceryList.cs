using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuickList.Models
{
    public class GroceryList
    {
        [Key]
        public int GroceryListId { get; set; }

        [ForeignKey("Shopper")]
        public int ShopperId { get; set; }
        public Shopper Shopper { get; set; }

        public double EstimatedTotalCost { get; set; }

        public double RealTotalCost { get; set; }

        public string StoreName { get; set; }

        public DateTime Date { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public List<GroceryItems> GroceryItemsList { get; set; }

        //

 
    }
}
