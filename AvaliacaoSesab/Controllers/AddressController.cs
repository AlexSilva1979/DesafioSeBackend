using AvaliacaoSesab.Models;
using AvaliacaoSesab.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoSesab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IGeneralRepository _repository;
        public AddressController(IAddressRepository addressRepository, IGeneralRepository repository)
        {
            _addressRepository = addressRepository;
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<AddressModel> user = _addressRepository.GetAll();
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
                AddressModel address = _addressRepository.GetById(Id);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, erro ao listar os registros, detalhe do erro:{ex.Message}");
            }
        }

     
        [HttpPost]
        public async Task<IActionResult> Post(AddressModel model)
        {
            try
            {
               
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
        public async Task<IActionResult> Put(int Id, AddressModel model)
        {
            try
            {
                var address = _addressRepository.GetById(Id);

                if (address == null) {
                    NotFound(); 
                }
                else {
                    address.Street = model.Street;
                    address.ZipCode = model.ZipCode;
                    
                }


                _repository.Update(address);

                if (await _repository.SaveChangeAsync())
                {
                    address = _addressRepository.GetById(Id);
                    return Created($"/address/{model.Id}", address);
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
                var address = _addressRepository.GetById(Id);

                if (address == null) NotFound();


                _repository.Delete(address);

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
