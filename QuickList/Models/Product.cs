using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuickList.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        public string Description { get; set; }

    }
}
