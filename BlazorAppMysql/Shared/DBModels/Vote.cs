using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppMysql.Server
{
    [Table("vote")]
    public partial class Vote
    {
        public Vote()
        {
            Discussion = new HashSet<Discussion>();
            UserVote = new HashSet<UserVote>();
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
        [Column("DossierID", TypeName = "int(11)")]
        public int DossierId { get; set; }

        [ForeignKey(nameof(DossierId))]
        [InverseProperty("Vote")]
        public virtual Dossier Dossier { get; set; }
        [InverseProperty("Proposition")]
        public virtual ICollection<Discussion> Discussion { get; set; }
        [InverseProperty("Proposition")]
        public virtual ICollection<UserVote> UserVote { get; set; }
    }
}
