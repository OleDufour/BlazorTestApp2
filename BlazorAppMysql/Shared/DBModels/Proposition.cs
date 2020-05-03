using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppMysql.Shared.DBModels
{
    [Table("proposition")]
    public partial class Proposition
    {
        public Proposition()
        {
            Discussion = new HashSet<Discussion>();
            UserProposition = new HashSet<UserProposition>();
        }

        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        [StringLength(45)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Content { get; set; }
        [Column("CreatedByUserID", TypeName = "int(11)")]
        public int CreatedByUserId { get; set; }
        public DateTime? ClosedDate { get; set; }

        [InverseProperty("Proposition")]
        public virtual ICollection<Discussion> Discussion { get; set; }
        [InverseProperty("Proposition")]
        public virtual ICollection<UserProposition> UserProposition { get; set; }
    }
}
