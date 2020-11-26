using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_semanaoministack2.Models
{
    public class ClassSchedule
    {
        public int Id { get; set; }
        public int WeekDay { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int IdClass { get; set; }
        public Classes Class { get; set; }
    }
}
