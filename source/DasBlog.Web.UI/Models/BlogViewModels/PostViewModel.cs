using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasBlog.Web.UI.Models.BlogViewModels
{
    public class PostViewModel
    {
        public string Email { get; set; }
        public string Text { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string PreviousPost { get; set; }
        public string NextPost { get; set; }
        public string PermaLink { get; set; }
        public string Guid { get; set; }
        public string Comment { get; set; }
        public string Categories { get; set; }  
    }
}
