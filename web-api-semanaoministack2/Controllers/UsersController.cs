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
    public class UsersController : ControllerBase
    {
        private readonly AulasContext _aulasContext;
        public UsersController(AulasContext aulasContext)
        {
            _aulasContext = aulasContext;
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(DadosRegistro dados)
        {
            await using var transaction = await _aulasContext.Database.BeginTransactionAsync();

            try
            {
                _aulasContext.Users.Add(dados.User);
                await _aulasContext.SaveChangesAsync();
    
                dados.Class.IdUser = dados.User.Id;
                _aulasContext.Classes.Add(dados.Class);
                await _aulasContext.SaveChangesAsync();
                
                foreach (var schedule in dados.ClassSchedule)
                {
                    schedule.IdClass = dados.Class.Id;
                }

                _aulasContext.AddRange(dados.ClassSchedule);
                await _aulasContext.SaveChangesAsync();

                await transaction.CommitAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return StatusCode(500, new { Error = "Não foi possível registrar o usuário.", Exception = ex });
            }
        }
    }
}
