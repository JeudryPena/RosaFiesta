﻿using Domain.Entities.Enterprise;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class QuoteRepository : IQuoteRepository
{
	private readonly RosaFiestaContext _context;

	public QuoteRepository(RosaFiestaContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<QuoteEntity>> GetQuotesAsync(CancellationToken cancellationToken = default)
	=> await _context.Quotes.ToListAsync(cancellationToken);

	public async Task<IEnumerable<QuoteEntity>> GetQuotesByUserIdAsync(string userId, CancellationToken cancellationToken = default)
	{
		IEnumerable<QuoteEntity> quotes = await _context.Quotes.Where(q => q.UserId == userId).ToListAsync(cancellationToken);
		return quotes;
	}

	public async Task<QuoteEntity> GetQuoteAsync(Guid id, CancellationToken cancellationToken)
	{
		QuoteEntity? quote = await _context.Quotes.Include(x => x.Order).ThenInclude(x => x.Details).ThenInclude(x => x.PurchaseOptions).Include(x => x.Order).ThenInclude(x => x.Address).FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
		if (quote == null)
			throw new Exception("Quote not found");
		return quote;
	}

	public void CreateAsync(QuoteEntity quote, CancellationToken cancellationToken)
	=> _context.Quotes.AddAsync(quote, cancellationToken);

	public void Update(QuoteEntity quote)
	=> _context.Quotes.Update(quote);

	public async Task<QuoteEntity> GetQuoteByUserIdAsync(Guid id, string userId, CancellationToken cancellationToken = default)
	{
		QuoteEntity? quote = await _context.Quotes.FirstOrDefaultAsync(q => q.Id == id && q.UserId == userId, cancellationToken);
		if (quote == null)
			throw new Exception("Quote not found");
		return quote;
	}

	public void Delete(QuoteEntity quote)
	=> _context.Quotes.Remove(quote);

	public async Task<int> GetQuotesCountAsync(CancellationToken cancellationToken)
	{
		int count = await _context.Quotes.CountAsync(cancellationToken);
		return count;
	}
}