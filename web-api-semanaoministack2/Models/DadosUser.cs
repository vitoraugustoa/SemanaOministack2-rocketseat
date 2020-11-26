using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_semanaoministack2.Models
{
    public class DadosUser
    {
        public int Id { get; set; }
        public string Whatsapp { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }
        public string Subject { get; set; }
        public decimal Cost { get; set; }
    }
}
