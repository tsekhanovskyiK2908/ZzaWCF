using System;
using System.Collections.Generic;
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
        public Order Order { get; set; }
        [DataMember]
        public long OrderId { get; set; }
        public Product Product { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }        
    }
}
