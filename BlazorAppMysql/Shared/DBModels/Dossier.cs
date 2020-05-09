using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppMysql.Server
{
    [Table("dossier")]
    public partial class Dossier
    {
        public Dossier()
        {
            Vote = new HashSet<Vote>();
        }

        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(145)]
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        [Column("UserID", TypeName = "int(11)")]
        public int UserId { get; set; }

        [InverseProperty("Dossier")]
        public virtual ICollection<Vote> Vote { get; set; }
    }
}
