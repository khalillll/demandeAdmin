using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demandeAdmin.Models
{
    public class Demande
    {

        public int id { get; set; }

        public int documentId { get; set; }

        public int commentId { get; set; }

        public DateTime requestDate { get; set; }

        public string flag { get; set; }

        public int stateId { get; set; }



        [ForeignKey("User")]
        public int userId { get; set; }
        public User user { get; set; }


        public ICollection<Document> documents { get; set; }


        public ICollection<Comment> comments { get; set; }

    }
}