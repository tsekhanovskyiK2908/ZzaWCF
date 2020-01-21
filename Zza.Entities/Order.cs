using System;
using System.Collections.Generic;
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
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        [DataMember]
        public Guid CustomerId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        [DataMember]
        public Guid OrderStatusId { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public decimal ItemsTotal { get; set; }

    }
}
