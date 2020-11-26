using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_semanaoministack2.Models
{
    public class DadosRegistro
    {
        public Users User { get; set; }
        public Classes Class { get; set; }
        public List<ClassSchedule> ClassSchedule { get; set; }
    }
}
