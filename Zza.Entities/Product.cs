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
        public string Image { get; set; }
        [Required]
        public bool HasOptions { get; set; }
        public bool IsVegetarian { get; set; }
        public bool WithTomatoSauce { get; set; }
        public string SizeIds { get; set; }
    }
}
