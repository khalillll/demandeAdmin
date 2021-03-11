using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demandeAdmin.Models
{
    public class Comment
    {
        public int id { get; set; }

        public string body { get; set; }

        public DateTime dateComment { get; set; }
    }
}