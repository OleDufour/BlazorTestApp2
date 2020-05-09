using BlazorAppMysql.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppMysql.Server
{
    [Table("discussion")]
    public partial class Discussion
    {
        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("UserID")]
        [StringLength(45)]
        public string UserId { get; set; }
        [Required]
        [StringLength(250)]
        public string Content { get; set; }
        [Column("PropositionID", TypeName = "int(11)")]
        public int PropositionId { get; set; }

        [ForeignKey(nameof(PropositionId))]
        [InverseProperty("Discussion")]
        public virtual Proposition Proposition { get; set; }
    }
}
