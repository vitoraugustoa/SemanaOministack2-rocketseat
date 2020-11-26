using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_semanaoministack2.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Subject { get; set; }
        public decimal Cost { get; set; }
        public List<ClassSchedule> ClassSchedules { get; set; }
    }
}
