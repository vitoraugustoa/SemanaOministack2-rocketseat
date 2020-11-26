using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_semanaoministack2.Models
{
    public class Connections
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
