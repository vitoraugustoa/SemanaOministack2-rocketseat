using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_semanaoministack2.Data;
using web_api_semanaoministack2.Models;

namespace web_api_semanaoministack2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConexoesController : ControllerBase
    {
        private readonly AulasContext _aulasContext;
        public ConexoesController(AulasContext aulasContext)
        {
            _aulasContext = aulasContext;
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Connections connections)
        {
            try
            {
                _aulasContext.Connections.Add(connections);
                await _aulasContext.SaveChangesAsync();
                return Ok(connections);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Não foi possível registrar a conexão.", Exception = ex });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _aulasContext.Connections.CountAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Não foi possível buscar a quantidade de conexões.", Exception = ex });
            }
        }
    }
}
