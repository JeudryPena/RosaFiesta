using Domain.IRepository;
using Services.Abstractions;

namespace Services;

public class PayMethodService: IPayMethodService
{
    private readonly IRepositoryManager _repositoryManager;
    
    public PayMethodService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
}