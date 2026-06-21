using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Evently.Modules.Events.Api.Database;
using Microsoft.AspNetCore.Http;

namespace Evently.Modules.Events.Api.Events;
public static class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async (Request request, EventsDbContext dbContext) =>
        {
            var @event = new Event
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                StartsAtUtc = request.StartsAtUtc,
                EndsAtUtc = request.EndsAtUtc,
                Status = EventStatus.Draft
            };

            dbContext.Events.Add(@event);
            await dbContext.SaveChangesAsync();

            return Results.Ok(@event.Id);
        })
            .WithTags(Tags.Events);
    }

    internal sealed class Request
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartsAtUtc { get; set; }
        public DateTime? EndsAtUtc { get; set; }
    }
}
