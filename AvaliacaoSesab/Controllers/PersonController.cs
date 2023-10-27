
using AvaliacaoSesab.Models;
using AvaliacaoSesab.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoSesab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IGeneralRepository _repository;

        public PersonController(IPersonRepository personRepository, IGeneralRepository repository)
        {
            _personRepository = personRepository;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<PersonModel> person = _personRepository.GetAll();
                return Ok(person);
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
                PersonModel person = _personRepository.GetById(Id);
                return Ok(person);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao listar os registros, detalhe do erro:{ex.Message}");
            }
        }

        [HttpGet("CPF/{CPF}")]
        public IActionResult GetByCPF(string CPF)
        {
            try
            {
                PersonModel person = _personRepository.GetByCPF(CPF);
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


        [HttpGet("dateStart/{Data}")]
        public IActionResult GetByData(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                PersonModel person = _personRepository.GetByData(dateStart, dateEnd);
                return Ok(person);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao listar os registros, detalhe do erro:{ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(PersonModel model)
        {
            try
            {
                _repository.Add(model);

                if (await _repository.SaveChangeAsync())
                {
                    return Created($"/person/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao tentar salvar o registro, detalhe do erro:{ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, PersonModel model)
        {
            try
            {
                var person = _personRepository.GetById(Id);

                if (person == null)
                {
                    NotFound();
                }
                else {
                    person.Name = model.Name;
                    person.Email = model.Email;
                    person.Document = model.Document;
                    person.Profile  = model.Profile;
                    person.Address = model.Address;
                }
                
                _repository.Update(person);

                if (await _repository.SaveChangeAsync())
                {
                    person = _personRepository.GetById(Id);
                    return Created($"/person/{model.Id}", person);
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
                var person = _personRepository.GetById(Id);

                if (person == null) NotFound();

                _repository.Delete(person);

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
