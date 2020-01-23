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
    public class Customer
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [Required]
        public string FirstName { get; set; }
        [DataMember]
        [Required]
        public string LastName { get; set; }
        [DataMember]
        [Required]
        public string Phone { get; set; }
        [DataMember]
        [Required]
        public string Email { get; set; }
        [DataMember]
        [Required]
        public string Street { get; set; }
        [DataMember]
        [Required]
        public string City { get; set; }
        [DataMember]
        [Required]
        public string State { get; set; }
        [DataMember]
        [Required]
        public string Zip { get; set; }
        [DataMember]
        public string FullName 
        { 
            get
            {
                return $"{FirstName} {LastName}";
            }
            set { }                 
        }
    }
}
