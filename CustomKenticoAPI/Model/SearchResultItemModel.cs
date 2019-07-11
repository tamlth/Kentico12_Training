using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomKenticoAPI.Model
{
    public class SearchResultItemModel
    {
        public SearchResultItemModel() { }

        public string DocumentExtensions { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Index { get; set; }
        public float MaxScore { get; set; }
        public int Position { get; set; }
        public double Score { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
    }
}
