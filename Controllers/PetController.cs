using Microsoft.AspNetCore.Mvc;
using PetStore.API.Interfaces;
using PetStore.API.Models;
using PetStore.API.Models.Pet.CreateModels;
using PetStore.API.Models.Pet.UpdateModels;
using PetStore.API.Models.Pet.ViewModels;

namespace PetStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly ILogger<PetController> _logger;
        private readonly IPetService _petService;

        public PetController(ILogger<PetController> logger, IPetService petService)
        {
            _logger = logger;
            _petService = petService;
        }

        [HttpGet("[action]")]
        public async Task<CustomResponseModel<IEnumerable<PetViewModel>>> GetAll()
        {
            try
            {
                return _petService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return new CustomResponseModel<IEnumerable<PetViewModel>>()
                {
                    StatusCode = 400,
                    ErrorMessage = "Something went wrong"
                };
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<CustomResponseModel<PetViewModel>> GetById(int id)
        {
            try
            {
                return _petService.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return new CustomResponseModel<PetViewModel>()
                {
                    StatusCode = 400,
                    ErrorMessage = "Something went wrong"
                };
            }
        }

        [HttpPost("[action]")]
        public async Task<CustomResponseModel<bool>> Create([FromQuery] PetCreateModel petCreateModel)
        {
            try
            {
                return _petService.Create(petCreateModel);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return new CustomResponseModel<bool>()
                {
                    StatusCode = 400,
                    ErrorMessage = "Something went wrong",
                    Result = false
                };
            }
        }


        [HttpPut("[action]")]
        public async Task<CustomResponseModel<bool>> Update([FromQuery] PetUpdateModel petUpdateModel)
        {
            try
            {
                return _petService.Update(petUpdateModel);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return new CustomResponseModel<bool>()
                {
                    StatusCode = 400,
                    ErrorMessage = "Something went wrong",
                    Result = false
                };
            }
        }

        [HttpDelete("[action]/{id}")]
        public async Task<CustomResponseModel<bool>> Delete(int id)
        {
            try
            {
                return _petService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return new CustomResponseModel<bool>()
                {
                    StatusCode = 400,
                    ErrorMessage = "Something went wrong",
                    Result = false
                };
            }
        }

    }
}
