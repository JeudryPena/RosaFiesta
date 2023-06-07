using Domain.Entities.Enterprise;

namespace Domain.IRepository;

public interface IQuoteRepository
{
	Task<IEnumerable<QuoteEntity>> GetQuotesAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<QuoteEntity>> GetQuotesByUserIdAsync(string userId, CancellationToken cancellationToken = default);
	Task<QuoteEntity> GetQuoteAsync(int id, CancellationToken cancellationToken = default);
	void CreateAsync(QuoteEntity quote, CancellationToken cancellationToken = default);
	void Update(QuoteEntity quote);
	Task<QuoteEntity> GetQuoteByUserIdAsync(int id, string userId, CancellationToken cancellationToken = default);
}