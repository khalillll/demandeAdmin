using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demandeAdmin.Models
{
    public class Comment
    {
        public int id { get; set; }

        public string body { get; set; }

        public DateTime dateComment { get; set; }



        [ForeignKey("Demande")]
        public int demandeId { get; set; }
        public Demande demande { get; set; }


        [ForeignKey("User")]
        public int userId { get; set; }
        public User user { get; set; }
    }
}