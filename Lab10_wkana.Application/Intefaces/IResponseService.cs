using Lab10_wkana.Application.Dtos.Response;

namespace Lab10_wkana.Application.Intefaces;

public interface IResponseService
{
    Task<List<ResponseDto>> GetAllResponsesAsync();
    Task<ResponseDto> GetReponseByIdAsync(int responseId);
}