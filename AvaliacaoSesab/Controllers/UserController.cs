using AvaliacaoSesab.Models;
using AvaliacaoSesab.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoSesab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IGeneralRepository _repository;
        public UserController(IUserRepository userRepository, IGeneralRepository repository)
        {
            _userRepository = userRepository;
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<UserModel> user = _userRepository.GetAll();
                return Ok(user);
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
                UserModel user = _userRepository.GetById(Id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao listar os registros, detalhe do erro:{ex.Message}");
            }
        }

     
        [HttpPost]
        public async Task<IActionResult> Post(UserModel model)
        {
            try
            {
                model.DateCreated = DateTime.Now;
                model.SetPasswordHash();
                _repository.Add(model);

                if (await _repository.SaveChangeAsync())
                {
                    return Created($"/user/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao tentar salvar o registro, detalhe do erro:{ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, UserModel model)
        {
            try
            {
                var user = _userRepository.GetById(Id);

                if (user == null) {
                    NotFound(); 
                }
                else {
                    user.Name = model.Name;
                    user.Email = model.Email;
                    user.Password = model.Password;
                }

                user.SetPasswordHash();

                _repository.Update(user);

                if (await _repository.SaveChangeAsync())
                {
                    user = _userRepository.GetById(Id);
                    return Created($"/user/{model.Id}", user);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao tentar atualizar o registro, detalhe do erro:{ex.Message}");
            }
            return BadRequest();
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var user = _userRepository.GetById(Id);

                if (user == null) NotFound();


                _repository.Delete(user);

                if (await _repository.SaveChangeAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao tentar excluir o registro, detalhe do erro:{ex.Message}");
            }
            return BadRequest();
        }
    }

}
