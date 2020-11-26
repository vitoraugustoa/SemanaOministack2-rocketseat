using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using web_api_semanaoministack2.Data;
using web_api_semanaoministack2.Models;

namespace web_api_semanaoministack2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        private readonly AulasContext _aulasContext;
        public AulasController(AulasContext aulasContext)
        {
            _aulasContext = aulasContext;
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Classes classe)
        {
            try
            {
                _aulasContext.Classes.Add(classe);
                await _aulasContext.SaveChangesAsync();
                return Ok(classe);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { Error = "Não foi possível registrar a aula.", Exception = ex });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Buscar(int? weekDay, string subject, int? time)
        {
            if (!weekDay.HasValue || string.IsNullOrEmpty(subject) || !time.HasValue)
                return BadRequest();

            try
            {
                string query = @"SELECT Users.Id, Users.Name, Users.Avatar, Users.Bio, Users.Whatsapp, Classes.Subject, Classes.Cost FROM Classes
                                    INNER JOIN Users ON Classes.IdUser = Users.Id
                                    INNER JOIN ClassSchedule on ClassSchedule.IdClass = Classes.Id
                                    WHERE ClassSchedule._WeekDay = @weekday AND Classes.Subject = @subject
                                    AND (ClassSchedule._From >= @time OR ClassSchedule._To <= @time)";

                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@time", time),
                    new SqlParameter("@weekday", weekDay),
                    new SqlParameter("@subject", subject)
                };

                return Ok(await _aulasContext.DadosUser.FromSqlRaw(query, parameters.ToArray()).ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Não foi possível listar as aula.", Exception = ex });
            }
        }
    }
}
