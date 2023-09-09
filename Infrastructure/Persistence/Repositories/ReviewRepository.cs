using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class ReviewRepository : Repository<Review>, IReviewRepository
{
    public ReviewRepository(ApplicationDbContext context) : base(context)
    {
    }
}