namespace DPAContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Comments = new HashSet<Comment>();
            Requests = new HashSet<Request>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50)]
        [DisplayName("Prénom")]
        public string firstName { get; set; }

        [StringLength(50)]
        [DisplayName("Nom")]
        public string lastName { get; set; }

        [StringLength(255)]
        [EmailAddress]
        [DisplayName("Email")]
        [RegularExpression("^[_A-Za-z'`+-.]+([_A-Za-z0-9'+-.]+)*@([A-Za-z0-9-])+(\\.[A-Za-z0-9]+)*(\\.([A-Za-z]*){3,})$", ErrorMessage = "Enter proper email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Format not proper of email address")]
        public string email { get; set; }

        [StringLength(255)]
        public string password { get; set; }
        [DisplayName("Etat")]
        public byte? state { get; set; }
        [DisplayName("Date de création")]
        public DateTime? createdAt { get; set; }
        [DisplayName("Dernière modification")]
        public DateTime? updatedAt { get; set; }
        [DisplayName("Role")]
        public int? roleId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }

        public virtual Role Role { get; set; }
    }
}
