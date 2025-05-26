using Lab10_wkana.Application.Dtos.Response;
using Lab10_wkana.Application.Intefaces;
using Lab10_wkana.Domain.Entities;
using Lab10_wkana.Domain.Interfaces.Base;
using Mapster;

namespace Lab10_wkana.Application.Services;

public class ResponseService : IResponseService
{
    private readonly IUnitOfWork _unitOfWork;

    public ResponseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ResponseDto>> GetAllResponsesAsync()
    {
        var responses = await _unitOfWork.Repository<Response>().GetAllAsync();
        return responses.Adapt<List<ResponseDto>>();
    }
    
    public async Task<ResponseDto> GetReponseByIdAsync(int responseId)
    {
        var responses = await _unitOfWork.Repository<Response>().GetByIdAsync(responseId);
        return responses.Adapt<ResponseDto>();
    }
    
}