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
    public class Order
    {
        [DataMember]
        public long Id { get; set; }
        public Guid StoreId { get; set; }
        public Customer Customer { get; set; }
        [DataMember]
        public Guid CustomerId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        [DataMember]
        public int OrderStatusId { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        [StringLength(100)]        
        public string Phone { get; set; }

        [DataMember]
        public DateTime DeliveryDate { get; set; }

        [DataMember]
        public decimal DeliveryCharge { get; set; }

        [DataMember]
        [StringLength(100)]
        public string DeliveryStreet { get; set; }

        [DataMember]
        [StringLength(100)]
        public string DeliveryCity { get; set; }

        [DataMember]
        [StringLength(2)]
        public string DeliveryState { get; set; }

        [DataMember]
        [StringLength(10)]
        public string DeliveryZip { get; set; }

        [DataMember]
        public decimal ItemsTotal { get; set; }

    }
}
