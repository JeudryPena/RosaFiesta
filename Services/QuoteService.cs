using Contracts.Model.Enterprise;
using Contracts.Model.Enterprise.Response;
using Domain.Entities.Enterprise;
using Domain.Entities.Security;
using Domain.Entities.Security.Helper;
using Domain.IRepository;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class QuoteService: IQuoteService
{
    private readonly IRepositoryManager _repositoryManager;
    
    public QuoteService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<QuotePreviewResponse>> GetQuotesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<QuoteEntity> quotes = await _repositoryManager.QuoteRepository.GetQuotesAsync(cancellationToken);
        IEnumerable<QuotePreviewResponse> quotePreviewResponses = quotes.Adapt<IEnumerable<QuotePreviewResponse>>();
        return quotePreviewResponses;
    }

    public async Task<IEnumerable<QuotePreviewResponse>> GetQuotesByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        IEnumerable<QuoteEntity> quotes = await _repositoryManager.QuoteRepository.GetQuotesByUserIdAsync(userId, cancellationToken);
        IEnumerable<QuotePreviewResponse> quotePreviewResponses = quotes.Adapt<IEnumerable<QuotePreviewResponse>>();
        return quotePreviewResponses;
    }

    public async Task<QuoteResponse> GetQuoteAsync(int id, CancellationToken cancellationToken = default)
    {
        QuoteEntity quote = await _repositoryManager.QuoteRepository.GetQuoteAsync(id, cancellationToken);
        QuoteResponse quoteResponse = quote.Adapt<QuoteResponse>();
        return quoteResponse;
    }
    
    public async Task<QuoteResponse> CreateQuoteAsync(QuoteDto quoteDto, CancellationToken cancellationToken)
    {
        QuoteEntity quote = quoteDto.Adapt<QuoteEntity>();
        foreach (var q in quote.QuoteItems)
            await _repositoryManager.ServiceRepository.AvaliableService(q.ServiceId, q.Quantity, cancellationToken);
        _repositoryManager.QuoteRepository.CreateAsync(quote, cancellationToken);
        ActionLogEntity actionLog = new()
        {
            ActivityType = Activities.Quote,
            Action = ActivityAction.Created,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        QuoteResponse quoteResponse = quote.Adapt<QuoteResponse>();
        return quoteResponse;
    }

    public async Task<QuoteResponse> CreateUserQuoteAsync(string userId, QuoteDto quoteDto, CancellationToken cancellationToken)
    {
        QuoteEntity quote = quoteDto.Adapt<QuoteEntity>();
        quote.UserId = userId;
        foreach (var q in quote.QuoteItems)
            await _repositoryManager.ServiceRepository.AvaliableService(q.ServiceId, q.Quantity, cancellationToken);
        _repositoryManager.QuoteRepository.CreateAsync(quote, cancellationToken);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Quote,
            Action = ActivityAction.Created,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        QuoteResponse quoteResponse = quote.Adapt<QuoteResponse>();
        return quoteResponse;
    }

    public async Task<QuoteResponse> UpdateQuoteAsync(int id, QuoteUpdateDto quoteDto, string userId,
        CancellationToken cancellationToken)
    {
        QuoteEntity quote = await _repositoryManager.QuoteRepository.GetQuoteByUserIdAsync(id, userId, cancellationToken);
        quoteDto.Adapt(quote);
        quote.UpdatedAt = DateTimeOffset.Now;
        if(quoteDto.QuoteItems != null)
            foreach (var q in quote.QuoteItems)
                await _repositoryManager.ServiceRepository.AvaliableService(q.ServiceId, q.Quantity, cancellationToken);
        _repositoryManager.QuoteRepository.Update(quote);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Quote,
            Action = ActivityAction.Updated,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        QuoteResponse quoteResponse = quote.Adapt<QuoteResponse>();
        return quoteResponse;
    }

    public async Task DeleteQuoteAsync(int id, string userId, CancellationToken cancellationToken = default)
    {
        QuoteEntity quote = await _repositoryManager.QuoteRepository.GetQuoteByUserIdAsync(id, userId, cancellationToken);
        foreach (var q in quote.QuoteItems)
            await _repositoryManager.ServiceRepository.RestoreQuantity(q.ServiceId, q.Quantity, cancellationToken);
        quote.IsDeleted = true;
        quote.UpdatedAt = DateTimeOffset.Now;
        _repositoryManager.QuoteRepository.Update(quote);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Quote,
            Action = ActivityAction.Deleted,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}