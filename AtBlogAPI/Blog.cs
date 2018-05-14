using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtBlogAPI.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public String CreatedBy { get; set; }
        public int TotalVotes { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}