using Domain.Entities.Enterprise;

namespace Domain.IRepository;

public interface IQuoteRepository
{
	Task<IEnumerable<QuoteEntity>> GetQuotesAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<QuoteEntity>> GetQuotesByUserIdAsync(string userId, CancellationToken cancellationToken = default);
	Task<QuoteEntity> GetQuoteAsync(Guid id, CancellationToken cancellationToken = default);
	void CreateAsync(QuoteEntity quote, CancellationToken cancellationToken = default);
	void Update(QuoteEntity quote);
	Task<QuoteEntity> GetQuoteByUserIdAsync(Guid id, string userId, CancellationToken cancellationToken = default);
	void Delete(QuoteEntity quote);
	Task<int> GetQuotesCountAsync(CancellationToken cancellationToken);
}