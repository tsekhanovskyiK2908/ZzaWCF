using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zza.Entities
{
    public class OrderItemOption
    {
        public long Id { get; set; }

        public Guid StoreId { get; set; }

        public OrderItem OrderItem { get; set; }
        
        [Required]
        public long OrderItemId { get; set; }

        public ProductOption ProductOption { get; set; }

        [Required]
        public int ProductOptionId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}
