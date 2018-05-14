using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtBlogAPI.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        public int BlogId { get; set; }
        [Required]
        public string VotedBy { get; set; }
        [Required]
        public int Rateing { get; set; }
    }
}


