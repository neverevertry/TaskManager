using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Comment
    {
        public int id { get; set; }

        public string text { get; set; }

        public int TaskId { get; set; }
    }
}
