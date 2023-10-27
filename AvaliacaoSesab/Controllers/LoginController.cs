
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
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IGeneralRepository _repository;
        
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }
        [HttpPost]
        public IActionResult SignIn(LoginModel loginModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    UserModel userModel = _userRepository.GetByEmail(loginModel.Email);
                    if (userModel != null)
                    {
                        if (userModel.PassWordValid(loginModel.PassWord))
                        {
                            return Ok(userModel);
                        }
                        else
                        {
                            return BadRequest("Senha inválido. Tente novamente.");
                        }
                    }
                    else
                    {
                        return BadRequest("Usuário e/ou senha inválido. Tente novamente.");
                    }

                }

                return View("Index");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao consultar o usuário, detalhe do erro:{ex.Message}");
            }

        }
    }


}
