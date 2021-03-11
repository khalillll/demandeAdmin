using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demandeAdmin.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public string state { get; set; }
       


        [ForeignKey("Role")]
        public int roleId { get; set; }
        public Role role { get; set; }


        public ICollection<Demande> demandes { get; set; }


        public ICollection<Comment> comments { get; set; }
    }
}