using System;
using System.Collections.Generic;

namespace BlazorAppMysql.Server.DtoModels
{
    public partial class PropositionDto
    {

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime? ClosedDate { get; set; }

        //public virtual ICollection<Discussion> Discussion { get; set; }
        //public virtual ICollection<UserProposition> UserProposition { get; set; }
    }
}
