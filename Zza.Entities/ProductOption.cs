using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zza.Entities
{
    public class ProductOption
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Factor { get; set; }
        [Required]
        public bool IsPizzaOption { get; set; }
        [Required]
        public bool IsSaladOption { get; set; }
    }
}
