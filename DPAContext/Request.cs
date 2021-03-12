namespace DPAContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request()
        {
            Comments = new HashSet<Comment>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(250)]
        public string title { get; set; }

        public DateTime? requestDate { get; set; }

        [StringLength(50)]
        public string flag { get; set; }

        public int? documentId { get; set; }

        public int? userId { get; set; }

        public int? commentId { get; set; }

        public int? stateId { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Document Document { get; set; }

        public virtual State State { get; set; }

        public virtual User User { get; set; }
    }
}
