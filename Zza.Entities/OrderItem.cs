using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zza.Entities
{   
    [DataContract]
    public class OrderItem
    {   
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public Guid StoreId { get; set; }

        public Order Order { get; set; }

        [DataMember]
        [Required]
        public long OrderId { get; set; }

        public Product Product { get; set; }

        [DataMember]
        [Required]
        public int ProductId { get; set; }

        public ProductSize ProductSize { get; set; }

        [DataMember]
        public int ProductSizeId { get; set; }

        [DataMember]
        [Required]
        public int Quantity { get; set; }

        [DataMember]
        [Required]
        public decimal UnitPrice { get; set; }

        [DataMember]
        [Required]
        public decimal TotalPrice { get; set; }

        [DataMember]
        [StringLength(255)]
        public string Instructions { get; set; }

    }
}
