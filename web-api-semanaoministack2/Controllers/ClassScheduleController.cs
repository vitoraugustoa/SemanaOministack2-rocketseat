using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_semanaoministack2.Data;
using web_api_semanaoministack2.Models;

namespace web_api_semanaoministack2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassScheduleController : ControllerBase
    {
        private readonly AulasContext _aulasContext;
        public ClassScheduleController(AulasContext aulasContext)
        {
            _aulasContext = aulasContext;
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(ClassSchedule classSchedule)
        {
            try
            {
                _aulasContext.ClassSchedules.Add(classSchedule);
                await _aulasContext.SaveChangesAsync();
                return Ok(classSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Não foi possível registrar os detalhes da aula.", Exception = ex });
            }
        }
    }
}
