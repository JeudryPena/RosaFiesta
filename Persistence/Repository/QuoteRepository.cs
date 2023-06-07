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
	=> await _context.Quotes.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);

	public async Task<IEnumerable<QuoteEntity>> GetQuotesByUserIdAsync(string userId, CancellationToken cancellationToken = default)
	{
		IEnumerable<QuoteEntity> quotes = await _context.Quotes.Where(q => q.UserId == userId && q.IsDeleted == false).ToListAsync(cancellationToken);
		return quotes;
	}

	public async Task<QuoteEntity> GetQuoteAsync(int id, CancellationToken cancellationToken)
	{
		QuoteEntity? quote = await _context.Quotes.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
		if (quote == null)
			throw new Exception("Quote not found");
		if (quote.IsDeleted)
			throw new Exception("Quote is deleted");
		return quote;
	}

	public void CreateAsync(QuoteEntity quote, CancellationToken cancellationToken)
	=> _context.Quotes.AddAsync(quote, cancellationToken);

	public void Update(QuoteEntity quote)
	=> _context.Quotes.Update(quote);

	public async Task<QuoteEntity> GetQuoteByUserIdAsync(int id, string userId, CancellationToken cancellationToken = default)
	{
		QuoteEntity? quote = await _context.Quotes.FirstOrDefaultAsync(q => q.Id == id && q.UserId == userId, cancellationToken);
		if (quote == null)
			throw new Exception("Quote not found");
		if (quote.IsDeleted)
			throw new Exception("Quote is deleted");
		return quote;
	}
}