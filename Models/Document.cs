using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demandeAdmin.Models
{
    public class Document
    {
        public int id { get; set; }
        public string type { get; set; }
        public string description { get; set; }




        public ICollection<Demande> demandes { get; set; }
    }
}