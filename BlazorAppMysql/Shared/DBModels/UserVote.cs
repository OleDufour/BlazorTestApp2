﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppMysql.Server
{
    [Table("user_vote")]
    public partial class UserVote
    {
        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("VoteID", TypeName = "int(11)")]
        public int VoteId { get; set; }
        [Column(TypeName = "tinyint(4)")]
        public byte VotedFor { get; set; }
        public DateTime VoteDate { get; set; }
        [StringLength(200)]
        public string Comment { get; set; }

        [ForeignKey(nameof(VoteId))]
        [InverseProperty(nameof(Vote.UserVote))]
        public virtual Vote Proposition { get; set; }
    }
}
