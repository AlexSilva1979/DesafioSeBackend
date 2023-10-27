
using AvaliacaoSesab.Helper;
using AvaliacaoSesab.Models;
using AvaliacaoSesab.Repository;
using AvaliacaoSesab.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoSesab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : Controller
    {
        private readonly IStatRepository _statRepository;
        
        public StatsController(IStatRepository statRepository)
        {
            _statRepository = statRepository;
            
        }
       
        public IActionResult Index()
        {
            try
            {
                var stat = _statRepository.GetAll();

                if (stat != null)
                    return Ok(stat);
                else 
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao listar as estatisticas, detalhe do erro:{ex.Message}");
            }
        }
       
    }


}
