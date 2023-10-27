using AvaliacaoSesab.Models;
using AvaliacaoSesab.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AvaliacaoSesab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        
        private readonly IProfileRepository _profileRepository;


        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<ProfileModel> profile = _profileRepository.GetAll();
                return Ok(profile);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao listar os registros, detalhe do erro:{ex.Message}");
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                ProfileModel profile = _profileRepository.GetById(Id);
                return Ok(profile);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao listar os registros, detalhe do erro:{ex.Message}");
            }
        }

    }

}
