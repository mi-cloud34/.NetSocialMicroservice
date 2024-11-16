using Conservation.WepAPI.Dto;
using Conservation.WepAPI.Model;
using Conservation.WepAPI.Response;

namespace Conservation.WepAPI.Services
{
    public interface IConservationService
    {

        Task<Response<List<ConservationDto>>> GetAllAsync();

        Task<Response<ConservationDto>> GetByIdAsync(string id);

      // Task<Response<List<ConservationDto>>> GetAllByUserIdAsync(string userId);

        Task<Response<ConservationCreateDto>> CreateAsync(ConservationCreateDto courseCreateDto);

        Task<Response<NoContent>> UpdateAsync(ConservationDto courseUpdateDto);

        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
