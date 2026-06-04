using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries
{
    public class GetActivityList
    {
        public class Query : IRequest<List<Activity>>
        {
        }

        public class Handler(AppDbContext context) : IRequestHandler<Query, List<Activity>>
        {
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                // CancellationToken is used to gracefully stop long-running, asynchronous, or background tasks before they finish.
                // Automatically aborts database queries or background processing if a client closes their browser tab or cancels a pending HTTP request.
                return await context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}