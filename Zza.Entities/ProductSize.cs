using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zza.Entities
{
    public class ProductSize
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal PremiumPrice { get; set; }
        public decimal ToppingPrice { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}
