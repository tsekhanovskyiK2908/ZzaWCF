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
    public class Product
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string Name { get; set; }
        [DataMember]
        [Required]
        public string Type { get; set; }
        [DataMember]
        [Required]
        public string Description { get; set; }

        [DataMember]
        public string Image { get; set; }
        [DataMember]
        [Required]
        public bool HasOptions { get; set; }

        [DataMember]
        public bool IsVegetarian { get; set; }

        [DataMember]
        public bool WithTomatoSauce { get; set; }

        [DataMember]
        public string SizeIds { get; set; }
    }
}
