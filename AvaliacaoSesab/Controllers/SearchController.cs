
using AvaliacaoSesab.Models;
using AvaliacaoSesab.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoSesab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly IPersonRepository _personRepository;
        

        public SearchController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpPost]
        public IActionResult GetAll(SearchModel model)
        {
            try
            {
                List<PersonModel> person = _personRepository.GetBySearch(model);
                return Ok(person);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao listar os registros, detalhe do erro:{ex.Message}");
            }
        }

        
        [HttpGet("search/{Search}")]
        public IActionResult GetBySearch(SearchModel model)
        {
            try
            {
                List<PersonModel> person = _personRepository.GetBySearch(model);
                return Ok(person);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao listar os registros, detalhe do erro:{ex.Message}");
            }
        }


    }

}
