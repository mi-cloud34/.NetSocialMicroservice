using Conservation.WepAPI.Dto;
using Conservation.WepAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conservation.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConservationsController : CustomBaseController
    {
        private readonly IConservationService _conservationService;
     
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public ConservationsController(IConservationService conservationService)
        {
            _conservationService = conservationService;
          
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _conservationService.GetAllAsync();
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        [Authorize()]
        public async Task<IActionResult> Add(ConservationCreateDto conservationDto)
        {
            // int userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var response = await _conservationService.CreateAsync(conservationDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        [Authorize()]
        public async Task<IActionResult> DeleteBasket(string id)

        {
            return CreateActionResultInstance(await _conservationService.DeleteAsync(id));
        }
    }
}
