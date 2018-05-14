using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtBlogAPI.Models.ViewModel
{
    public class AddVoteVm
    {
        public int BlogId { get; set; }
        public string VotedBy { get; set; }
        public int Rateing { get; set; }
    }
}