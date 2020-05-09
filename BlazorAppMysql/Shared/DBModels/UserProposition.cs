using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppMysql.Server
{
    [Table("user_proposition")]
    public partial class UserProposition
    {
        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("PropositionID", TypeName = "int(11)")]
        public int PropositionId { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public byte VotedFor { get; set; }
        public DateTime VoteDate { get; set; }
        [StringLength(200)]
        public string Comment { get; set; }

        [ForeignKey(nameof(PropositionId))]
        [InverseProperty("UserProposition")]
        public virtual Proposition Proposition { get; set; }
    }
}
