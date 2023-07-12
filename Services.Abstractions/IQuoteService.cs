using Contracts.Model.Enterprise;
using Contracts.Model.Enterprise.Response;

namespace Services.Abstractions;

public interface IQuoteService
{
	Task<IEnumerable<QuotePreviewResponse>> GetQuotesAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<QuotePreviewResponse>> GetQuotesByUserIdAsync(string userId, CancellationToken cancellationToken = default);
	Task<QuoteResponse> GetQuoteAsync(Guid id, CancellationToken cancellationToken = default);
	Task<QuoteResponse> CreateQuoteAsync(QuoteDto quoteDto, CancellationToken cancellationToken = default);
	Task<QuoteResponse> CreateUserQuoteAsync(string userId, QuoteDto quoteDto, CancellationToken cancellationToken = default);
	Task<QuoteResponse> UpdateQuoteAsync(Guid id, QuoteDto quoteDto, string userId,
		CancellationToken cancellationToken = default);
	Task DeleteQuoteAsync(Guid id, string userId, CancellationToken cancellationToken = default);
}