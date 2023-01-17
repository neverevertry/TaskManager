using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UserTask
    {
        public int id { get; set; }

        public string name { get; set; }

        public DateTime createTime { get; set; }

        public string description { get; set; }

        public DateTime close { get; set; }

        public List<Comment> comments { get; set; }

        public DateTime approximateDate {get;set;}

        public DateTime actualTime {get;set;}

        public int statusId { get; set; }

        public int userId { get; set; }
    }
}
