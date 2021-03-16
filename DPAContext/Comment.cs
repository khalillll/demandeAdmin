namespace DPAContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(250)]
        public string body { get; set; }

        public DateTime? dateComment { get; set; }

        public int? userId { get; set; }

        public int? requestId { get; set; }

        public virtual Request Request { get; set; }

        public virtual User User { get; set; }
    }
}
