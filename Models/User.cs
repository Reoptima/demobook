using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demobook.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
