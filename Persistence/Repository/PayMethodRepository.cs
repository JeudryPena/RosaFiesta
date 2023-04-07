﻿using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class PayMethodRepository: IPayMethodRepository
{
    private readonly RosaFiestaContext _context;
    
    public PayMethodRepository(RosaFiestaContext context)
    {
        _context = context;
    }
    
    public async Task<PayMethodEntity> GetByIdAsync(Guid payMethodId, CancellationToken cancellationToken)
    {
        PayMethodEntity? payMethod = await _context.PayMethods.FirstOrDefaultAsync(x => x.Id == payMethodId);
        if (payMethod == null) 
            throw new ArgumentNullException(nameof(payMethod));
        return payMethod;
    }

    public async Task<IEnumerable<PayMethodEntity>> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        IEnumerable<PayMethodEntity> payMethods = await _context.PayMethods.Where(x => x.UserId == userId).ToListAsync(cancellationToken) ?? throw new ArgumentNullException(nameof(payMethods));
        return payMethods;
    }

    public void Delete(PayMethodEntity payment)
    => _context.PayMethods.Remove(payment);

    public Guid? GetDefaultPaymentId(string userId, CancellationToken cancellationToken)
    {
        UserEntity? user = _context.Users.FirstOrDefault(x => x.Id == userId);
        if (user == null) 
            throw new ArgumentNullException(nameof(user));
        return user.DefaultPayMethodId;
    }

    public async Task<UserEntity> GetUserByDefaultPayment(string userId, Guid paymentId,
        CancellationToken cancellationToken = default)
    {
        UserEntity? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId && x.DefaultPayMethodId == paymentId, cancellationToken);
        if (user == null) 
            throw new ArgumentNullException(nameof(user));
        return user;
    }
}