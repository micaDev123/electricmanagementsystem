using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMSAPI.Models
{
    public class Users
    {
        [Key]
        [Column(TypeName = "VARCHAR(50)")]
        public string username{ get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")] 
        public string password { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string name { get; set; }
    }
}
