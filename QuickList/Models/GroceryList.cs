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

        [Display(Name = "List Name")]
        public string ListName { get; set; }
        public double? Budget { get; set; }

        [Display(Name = "Total Cost")]
        public double? RealTotalCost { get; set; }

        [Display(Name = "Store Name")]
        public string StoreName { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        public List<GroceryItems> GroceryItemsList { get; set; }

 
    }
}
